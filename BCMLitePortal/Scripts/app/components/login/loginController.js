app.controller('loginCtrl', function ($scope, loginService) {

    var tokenKey = 'accessToken';

    $scope.result = '';
    //$scppe.user = ko.observable();

    //$scppe.registerEmail = ko.observable();
    //$scppe.registerPassword = ko.observable();
    //$scppe.registerPassword2 = ko.observable();

    //$scppe.loginEmail = ko.observable();
    //$scppe.loginPassword = ko.observable();
    $scope.errors = [];

    ////Show error from login
    //function showError(jqXHR) {

    //    $scope.result = (jqXHR.status + ': ' + jqXHR.statusText);

    //    var response = jqXHR.responseJSON;
    //    if (response) {
    //        if (response.Message) $scope.errors.push(response.Message);
    //        if (response.ModelState) {
    //            var modelState = response.ModelState;
    //            for (var prop in modelState) {
    //                if (modelState.hasOwnProperty(prop)) {
    //                    var msgArr = modelState[prop]; // expect array here
    //                    if (msgArr.length) {
    //                        for (var i = 0; i < msgArr.length; ++i) $scope.errors.push(msgArr[i]);
    //                    }
    //                }
    //            }
    //        }
    //        if (response.error) $scope.errors.push(response.error);
    //        if (response.error_description) $scope.errors.push(response.error_description);
    //    }
    //}

    $scope.register = function () {
        //Reset scope variables
        $scope.result = '';
        $scope.errors = [];

        var data = {
            Email: $scope.registerEmail,
            Password: $scope.registerPassword,
            ConfirmPassword: $scope.registerPassword2
        };

        loginService.register(data).then(function (response) {

            $scope.result = 'Done';

        }, function (error) {

            $scope.result = error;
        });
    }

    $scope.login = function () {
        //Reset scope variables
        $scope.result = '';
        $scope.errors = [];

        var loginData = {
            grant_type: 'password',
            username: $scope.loginEmail,
            password: $scope.loginPassword
        };

        loginService.login(loginData).then(function (response) {

            // Cache the access token in session storage.
            sessionStorage.setItem(tokenKey, response.access_token);

        }, function (error) {

            $scope.result = error;
        });
    }
});