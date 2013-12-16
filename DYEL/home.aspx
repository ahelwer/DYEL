<h1>Welcome to DYEL, the fitness-oriented social network!</h1>

<h2>Sign Up or <a href="/login">Login</a></h2>
<form novalidate class="css-form">
    Username:   <input type="text"      ng-model="newUser.PersonId"     required /><br />
    Password:   <input type="text"      ng-model="newUser.Password" required /><br />
    Gender:     <input type="radio"     ng-model="newUser.Gender"   value="Male" />Male
                <input type="radio"     ng-model="newUser.Gender"   value="Female" />Female
                <input type="radio"     ng-model="newUser.Gender"   value="Other" />Other<br />
    Age:        <input type="number"    ng-model="newUser.Age"      required /><br />
    Focus:      <select ng-model="newUser.Focus" ng-options="focus.FocusId for focus in foci">
                    <option value="">-- choose focus --</option>
                </select> {{newUser.Focus.Description}}<br />
    <button ng-click="submitNewUser(newUser)">Submit</button>
</form>
<h3>Don't see your focus? Add it!</h3>
<form novalidate class="css-form">
    Focus:          <input type="text"  ng-model="newFocus.FocusId" required /><br />
    Description:    <textarea ng-model="newFocus.Description" cols="80" rows="1"></textarea><br />
    <button ng-click="submitNewFocus(newFocus)">Submit</button>
</form>
