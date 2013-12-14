<h2>Fitness Locations</h2>

<h3>Fitness locations you attend</h3>
<ul>
    <li ng-repeat="location in locations|filter:attendsFilter">
        <b>{{location.Name}}</b>
        <button ng-click="removeAttend(location.FitnessLocationId)">I no longer go here</button><br />
        <i>Address: {{location.Address}}</i><br />
        <i>Focus: {{location.Focus}}</i><br />
        <a ng-href="/workouts/{{location.FitnessLocationId}}"><i>Work out here</i></a>
    </li>
</ul>

<h3>Other locations you might attend</h3>
<ul>    <li ng-repeat="location in locations|filter:notAttendsFilter">
        <b>{{location.Name}}</b>
        <button ng-click="submitNewAttend(location.FitnessLocationId)">I go here!</button><br />
        <i>Address: {{location.Address}}</i><br />
        <i>Focus: {{location.Focus}}</i>
    </li>
</ul>

<h3>Don't see your favorite gym? Add it!</h3>

<form novalidate class="css-form">
    Name:       <input type="text"      ng-model="newLocation.Name"     required /><br />
    Address:    <input type="text"      ng-model="newLocation.Address"  required /><br />
    Focus:      <select ng-model="newLocation.Focus" ng-options="focus.FocusId for focus in foci">
                    <option value="">-- choose focus --</option>
                </select> {{newLocation.Focus.Description}}<br />
    <button ng-click="submitNewLocation(newLocation)">Submit</button>
</form>