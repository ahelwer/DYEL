<h2>Workouts Feed for {{personId}}</h2>
Following: {{following.length-1}} // Followers: {{followers.length-1}} // <a href="/follows">[Manage]</a><br />
<button ng-click="getWorkouts()">Refresh</button>

<h3>Broadcast upcoming workout</h3>
<form novalidate class="css-form">
    Location:       <select ng-model="newWorkout.LocationId" ng-options="location.Name for location in locations">
                        <option value="">-- choose location --</option>
                    </select><br />
    Description:    <textarea ng-model="newWorkout.Description" cols="80" rows="3"></textarea><br />
    Focus:          <select ng-model="newWorkout.Focus" ng-options="focus.FocusId for focus in foci">
                        <option value="">-- choose focus --</option>
                    </select> {{newWorkout.Focus.Description}}<br />
    Time:           <input type="datetime-local" ng-model="newWorkout.Time" />
    <button ng-click="broadcastWorkout(newWorkout)">Broadcast workout</button>
</form>

<h3>Your upcoming workouts</h3>
<div ng-repeat="workout in workouts | filter:attendingWorkouts">
    <b>Broadcast by {{workout.PersonId}}:</b><br />
    <p>{{workout.Description}}</p>
    <i>Where: {{getLocationDetails(workout.LocationId).Name}}</i><br />
    <i>When: {{workout.Time}}</i><br />
    <i>Focus: {{workout.Focus}}</i> 
    <button ng-click="removeJoin(workout.WorkoutId)">Withdraw</button><br />
    Will be attended by:
    <ul>
        <li ng-repeat="join in joiners[workout.WorkoutId] | filter:joinRequestNotRejected">
            {{join.PersonId}} 
            <button ng-show="join.Status == 0 && workout.PersonId == personId" ng-click="respond(join, 'Accepted')">Accept</button> 
            <button ng-show="join.Status == 0 && workout.PersonId == personId" ng-click="respond(join, 'Rejected')">Reject</button>
        </li>
    </ul>
</div>

<h3>Join an upcoming workout</h3>
<div ng-repeat="workout in workouts | filter:suggestedWorkouts">
    <b>Broadcast by {{workout.PersonId}}:</b><br />
    <p>{{workout.Description}}</p>
    <i>Where: {{getLocationDetails(workout.LocationId).Name}}</i><br />
    <i>When: {{workout.Time}}</i><br />
    <i>Focus: {{workout.Focus}}</i> 
    <button ng-click="requestJoin(workout.WorkoutId)">Request join</button><br />
    Will be attended by:
    <ul>
        <li ng-repeat="join in joiners[workout.WorkoutId] | filter:joinRequestAccepted">
            {{join.PersonId}}
        </li>
    </ul>
</div>
