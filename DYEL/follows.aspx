<h2>Manage follows for {{personId}}</h2>

<h3>Following</h3>
<ul>
    <li ng-repeat="person in people | filter:followingFilter">
        <button ng-click="unfollow(person.Id)">Unfollow</button>
        {{person.Id}} ({{description(person)}})
    </li>
</ul>

<h3>Followed by</h3>
<ul>
    <li ng-repeat="person in people | filter:followedByFilter">
        {{person.Id}} ({{description(person)}})
    </li>
</ul>

<h3>Follow someone new!</h3>
<ul>
    <li ng-repeat="person in people | filter:notFollowingFilter">
        <button ng-click="follow(person.Id)">Follow</button> 
        {{person.Id}} ({{description(person)}})
    </li>
</ul>