# LikeUnlikeButtonAsync
Implement the concept of Page Likes within a ASP.NET MVC Project

Feature Title

Implement the concept of Page Likes within a ASP.NET MVC Project

Description

We need to build a feature to allow authenticated users to like/unlike pages on our site.
Each page should display the total page count at the bottom.
Only authenticated users should be able to click the like/unlike button to mark their interest in the page.
If a user has already liked the current page, the like button should display the text ‘unlike’.
If a user hasn’t already liked the current page, the button should display the text ‘like’.
 

Acceptance Criteria

A Like/Unlike button should be displayed on each page for authenticated users only.
Only authenticated users can like/unlike a page.
Each page should display the total like count (even for unauthenticated users).
Users cannot like the same page multiple times. If a user has already liked a page, they can only unlike it.
Users can like or undo his/her like (unlike).
 

Technical Notes

Setup the basic ASP.NET MVC project (with default individual user accounts authentication) including Web API in the initial setup. (refer to attached screenshot)
All likes related (GET & POST) requests are to be done asynchronously such that page load times remain unaffected.
Make use of one or more Web API services to handle all asynchronous requests.
Start by storing the like/unlike related data in a static object, and if time permits, extend the standard data model to store like data in the database.
Perform all like async requests using JavaScript, using any framework of your choice.
If time permits, Structure your code as if you were building this for production.
