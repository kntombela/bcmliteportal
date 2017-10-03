app.service("loginService", function ($http) {

    //Register
    this.register = function (user) {
        return $http({
            method: "post",
            url: "/api/Account/Register",
            data: JSON.stringify(user),
            dataType: "json"
        });
    }

    //Login
    this.login = function (user) {
        return $http({
            method: "post",
            url: "/Token",
            data: user
        });
    }

    //Logout
    this.logout = function (headers) {
        return $http({
            method: "post",
            url: "/Token",
            headers: headers
        });
    }


});