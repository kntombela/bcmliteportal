app.controller('organisationCtrl', function ($scope, $q, $window, organisationService) {

    $scope.postOrganisation = function (organisation) {
        $scope.name = "";
        $scope.industry = "";
        $scope.type = "";

        organisationService.addNewOrganisation(organisation.organisationID).then(function (response) {

            $scope.name = response.name;
            $scope.industry = response.industry;
            $scope.type = response.type;

        }, (error) => {

            $scope.title = "Oops... something went wrong";
        });
    };

});