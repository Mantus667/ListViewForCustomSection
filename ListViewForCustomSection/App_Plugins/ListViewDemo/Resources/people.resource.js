angular.module("umbraco.resources")
        .factory("peopleResource", function ($http) {
            return {
                getall: function () {
                    return $http.get(Umbraco.Sys.ServerVariables.demoSection.demoBaseUrl + "GetAll");
                },

                getPaged: function (itemsPerPage, pageNumber, sortColumn, sortOrder, searchTerm) {
                    if (sortColumn == undefined)
                        sortColumn = "";
                    if (sortOrder == undefined)
                        sortOrder = "";
                    return $http.get(Umbraco.Sys.ServerVariables.demoSection.demoBaseUrl + "GetPaged?itemsPerPage=" + itemsPerPage + "&pageNumber=" + pageNumber + "&sortColumn=" + sortColumn + "&sortOrder=" + sortOrder + "&searchTerm=" + searchTerm);
                }
            };
        });