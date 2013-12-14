<h2>Login</h2>
<form novalidate class="css-form">
    Username:   <input type="text" ng-model="user.Id" required /><br />
    Password:   <input type="text" ng-model="user.Password" required />
    <button ng-click="submitLogin(user)">Login</button>
</form>