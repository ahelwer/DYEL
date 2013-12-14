<h2>Focus</h2>

<div>
    Your focus is {{user.Focus}}.<br />
</div>

<h3>List of Foci</h3>

<ul>
    <li ng-repeat="focus in foci">
        <b>{{focus.FocusId}}</b> - {{focus.Description}}
    </li>
</ul>

<h3>Don't see your focus? Add it!</h3>
<form novalidate class="css-form">
    Focus:          <input type="text"  ng-model="newFocus.FocusId" required /><br />
    Description:    <textarea ng-model="newFocus.Description" cols="80" rows="1"></textarea><br />
    <button ng-click="submitNewFocus(newFocus)">Submit</button>
</form>
