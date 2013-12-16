<h2>Manage follows for {{SessionName}}</h2>

<h3>Following</h3>
<ul>
    <li ng-repeat="person in people | filter:followingFilter">
        <button ng-click="unfollow(person.PersonId)">Unfollow</button>
        {{person.PersonId}} ({{description(person)}})
    </li>
</ul>

<h3>Followed by</h3>
<ul>
    <li ng-repeat="person in people | filter:followedByFilter">
        {{person.PersonId}} ({{description(person)}})
    </li>
</ul>

<h3>Follow someone new!</h3>
<ul>
    <li ng-repeat="person in people | filter:notFollowingFilter">
        <button ng-click="follow(person.PersonId)">Follow</button> 
        {{person.PersonId}} ({{description(person)}})
    </li>
</ul>