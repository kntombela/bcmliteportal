app.service("organisationService", function ($http) {

    //Get Organisation
    this.getOrganisation = function (organisationId) {
        return $http.get("/api/organisation/" + organisationId);
    }

    //Add Organisation
    this.addNewOrganisation = function (organisation) {
        return $http({
            method: "post",
            url: "api/organisation",
            data: organisation
        });
    }

    //Update Organisation
    this.updateOrganisation = function (quote) {
        return $http({
            method: "post",
            url: "api/QuotesViewModelApi",
            data: JSON.stringify(quote),
            dataType: "json"
        });
    }
    //Delete Organisation
    this.deleteOrganisation = function (id) {
        return $http({
            method: "delete",
            url: "api/QuotesViewModelApi/" + id
        });
    }
});  