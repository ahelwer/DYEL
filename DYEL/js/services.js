var dyelApp = angular.module('dyelApp');

// UTILITY SERVICE
dyelApp.factory('Utilities', function () {
    var functions = {};

    functions.clear = function (obj) {
        for (var key in obj) {
            obj[key] = null;
        }
    }

    functions.description = function (person) {
        var desc = person.Age + '-year-old ';
        if (person.Gender == 0) {
            desc += 'man ';
        }
        else if (person.Gender == 1) {
            desc += 'woman ';
        }
        else if (person.Gender == 2) {
            desc += '';
        }
        desc += 'focused on ' + person.Focus;
        return desc;
    }

    return functions;
});

// PERSON RESOURCE
dyelApp.factory('Person', function ($resource) {
    return $resource('/api/person', {}, {
        get:    { method: 'GET' },                  // (String requestedPerson) => Person
        getAll: { method: 'GET', isArray: true },   // () => IEnumerable<Person>
        login:  { method: 'GET' },                  // (String id, String password) => IHttpActionResult
        create: { method: 'POST' }                  // (String id, String password, String gender, int age, String focus) => IHttpActionResult
    });
});

// FOLLOWER RESOURCE
dyelApp.factory('Follower', function ($resource) {
    return $resource('/api/follower', {}, {
        following:  { method: 'GET', isArray: true },   // (String followerId) => IEnumerable<Follow>
        followers:  { method: 'GET', isArray: true },   // (String followeeId) => IEnumerable<Follow>
        follow:     { method: 'POST' },                 // (String followerId, String followeeId) => IHttpActionResult
        unfollow:   { method: 'DELETE' }                // (String followerId, String followeeId) => IHttpActionResult
    });
});

// POST RESOURCE
dyelApp.factory('Post', function ($resource) {
    return $resource('/api/post', {}, {
        getAll: { method: 'GET', isArray: true },   // (String personId) => IEnumerable<Post>
        create: { method: 'POST' }                  // (String personId, String text, String focus) => IHttpActionResult
    });
});

// COMMENT RESOURCE
dyelApp.factory('Comment', function ($resource) {
    return $resource('/api/comment', {}, {
        getAll: { method: 'GET', isArray: true },   // (Guid postId) => IEnumerable<Comment>
        create: { method: 'POST' }                  // (Guid postId, String personId, String text) => IHttpActionResult
    });
});

// WORKOUT RESOURCE
dyelApp.factory('Workout', function ($resource) {
    return $resource('/api/workout', {}, {
        getAll: { method: 'GET', isArray: true },   // (String personId) => IEnumerable<Workout>
        create: { method: 'POST' }                  // (String personId, Guid locationId, DateTime time, String description, String focus) => IHttpActionResult
    });
});

// JOINER RESOURCE
dyelApp.factory('Joiner', function ($resource) {
    return $resource('/api/joiner', {}, {
        getRequests:    { method: 'GET' },                  // (String personId) => IDictionary<Guid, IEnumerable<Joiner>>
        getJoiners:     { method: 'GET', isArray: true },   // (Guid workoutId) => IEnumerable<Joiner>
        postRequest:    { method: 'POST' },                 // (String personId, Guid workoutId) => IHttpActionResult
        respond:        { method: 'PUT' },                  // (String personId, Guid workoutId, Response status) => IHttpActionResult
        removeRequest:  { method: 'DELETE' }                // (String personId, Guid workoutId) => IHttpActionResult
    });
});

// FOCUS RESOURCE
dyelApp.factory('Focus', function ($resource) {
    return $resource('/api/focus', {}, {
        getAll: { method: 'GET', isArray: true },   // () => IEnumerable<Focus>
        create: { method: 'POST' }                  // (String focusId, String description) => IHttpActionResult
    });
});

// FITNESS LOCATION RESOURCE
dyelApp.factory('FitnessLocation', function ($resource) {
    return $resource('/api/fitnesslocation', {}, {
        get:    { method: 'GET' },                  // (Guid fitnessLocationId) => FitnessLocation
        getAll: { method: 'GET', isArray: true },   // () => IEnumerable<FitnessLocation>
        create: { method: 'POST' }                  // (String name, String address, String focus) => IHttpActionResult
    });
});

// ATTENDS RESOURCE
dyelApp.factory('Attends', function ($resource) {
    return $resource('/api/attends', {}, {
        attends:    { method: 'GET', isArray: true },   // (String personId) => IEnumerable<Attends>
        attending:  { method: 'GET', isArray: true },   // (Guid locationId) => IEnumerable<Attends>
        add:        { method: 'POST' },                 // (String personId, Guid locationId) => IHttpActionResult
        remove:     { method: 'DELETE' }                // (String personId, Guid locationId) => IHttpActionResult
    });
});