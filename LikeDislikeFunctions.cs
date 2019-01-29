using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using System.Security.Principal;

namespace CleverbitLikeUnlikePagesApp
{
    public class LikeDislikeFunctions
    {
        public string Like(Guid userId, int id, bool status)
        {
            using (var db = new DbEntities()) //this dbentities to access class from Model also we will get in web.config  
            {
                var thread = db.Threads.FirstOrDefault(x => x.ThreadId == id);
                var toggle = false;
                Like like = db.Likes.FirstOrDefault(x => x.ThreadId == id && x.UserId == userId);
                // check whether user clicked like or dislike    
                if (like == null)
                {
                    like = new Like();
                    like.UserId = userId;
                    like.IsLike = status;
                    like.ThreadId = id;
                    if (status)
                    {
                        if (thread.LikeCount == null) // if no one has done like or dislike and first time any one doing like and dislike then assigning 1 and                                                                                0    
                        {
                            thread.LikeCount = thread.LikeCount ?? 0 + 1;
                            thread.DislikeCount = thread.DislikeCount ?? 0;
                        }
                        else
                        {
                            thread.LikeCount = thread.LikeCount + 1;
                        }
                    }
                    else
                    {
                        if (thread.DislikeCount == null)
                        {
                            thread.DislikeCount = thread.DislikeCount ?? 0 + 1;
                            thread.LikeCount = thread.LikeCount ?? 0;
                        }
                        else
                        {
                            thread.DislikeCount = thread.DislikeCount + 1;
                        }
                    }
                    db.Likes.Add(like);
                }
                else
                {
                    toggle = true;
                }
                if (toggle)
                {
                    like.UserId = userId;
                    like.IsLike = status;
                    like.ThreadId = id;
                    if (status)
                    {
                        // if user clicks like then increase +1 in like and -1 in Dislike    
                        thread.LikeCount = thread.LikeCount + 1;
                        if (thread.DislikeCount == 0 || thread.DislikeCount < 0)
                        {
                            thread.DislikeCount = 0;
                        }
                        else
                        {
                            thread.DislikeCount = thread.DislikeCount - 1;
                        }
                    }
                    else
                    {
                        // if user clicks dislike button then increase +1 in dislike and -1 in like    
                        thread.DislikeCount = thread.DislikeCount + 1;
                        if (thread.LikeCount == 0 || thread.LikeCount < 0)
                        {
                            thread.LikeCount = 0;
                        }
                        else
                        {
                            thread.LikeCount = thread.LikeCount - 1;
                        }
                    }
                }
                db.SaveChanges();
                return thread.LikeCount + "/" + thread.DislikeCount;
            }
        }

        public int? Getlikecounts(int id) // to count like  
        {
            using (var db = new DbEntities())
            {
                var count = (from x in db.Threads where (x.ThreadId == id && x.LikeCount != null) select x.LikeCount).FirstOrDefault();
                return count;
            }
        }

        //Get Dislike Count  
        public int? Getdislikecounts(int id)
        {
            using (var db = new DbEntities())
            {
                var count = (from x in db.Threads where x.ThreadId == id && x.DislikeCount != null select x.DislikeCount).FirstOrDefault();
                return count;
            }
        }
        // to get all users who have done like and dislike 
        public List<Like> GetallUser(int id)
        {
            using (var db = new DbEntities())
            {
                var count = (from x in db.Likes where x.ThreadId == id select x).ToList();
                return count;
            }
        }

    }
}