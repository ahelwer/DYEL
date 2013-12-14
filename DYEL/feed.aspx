<h2>Discussion Feed for {{personId}}</h2>
Following: {{following.length-1}} // Followers: {{followers.length-1}} // <a href="/follows">[Manage]</a><br />
<button ng-click="getPosts()">Refresh</button>

<h3>Write new post</h3>
<form novalidate class="css-form">
    Text:   <textarea ng-model="newPost.Text" cols="80" rows="3"></textarea><br />
    Focus:  <select ng-model="newPost.Focus" ng-options="focus.FocusId for focus in foci">
                <option value="">-- choose focus --</option>
            </select> {{newPost.Focus.Description}}<br />
    <button ng-click="submitPost(newPost)">Submit post</button>
</form>
<br />
<div ng-repeat="post in posts">
    <b>Posted by {{post.PersonId}} at {{post.Time}}:</b><br />
    <p>{{post.Text}}</p>
    <i>Focus: {{post.Focus}}</i>
    <ul>
        <li ng-repeat="comment in comments[post.PostId]">
            <i>Posted by {{comment.PersonId}} at {{comment.Time}}:</i><br />
            {{comment.Text}}
        </li>
    </ul>
    <form novalidate class="css-form">
        Comment <textarea ng-model="post.newComment.Text" cols="80" rows="1"></textarea>
        <button ng-click="submitComment(post.newComment, post.PostId)">Submit</button>
    </form>
    <br /><br />
</div>