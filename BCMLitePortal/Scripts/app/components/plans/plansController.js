app.controller('planCtrl', function ($scope, $q, $window, plansService) {

    //Variables
    $scope.plans = [];
    $scope.title = "";

    $scope.getPlans = function (organisationId) {
        plansService.getOrganisationPlans(organisationId).then(function (response) {
            $scope.plans = response.data;
        }, (error) => {
            $scope.title = "Oops... something went wrong";
        });
    };
});