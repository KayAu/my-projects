bizModule.directive('multipleImageUploader', function ($q) {

    return {
      
        scope: {
            uploadedImages: '=uploadedImages',
            fileuploader:'@fileUploader'
        },
        template:
                '<a class="btn btn-success fileinput-button" ng-click="browseImage()" >' +
                    '<i class="glyphicon glyphicon-plus"></i>' +
                    '<span>Add pictures...</span>' +
                 '</a>' +
                 '<table class="table-files">' +
                    '<tbody>' +
                        '<tr ng-repeat="image in uploadedImages" ng-class-odd ="\'odd-row\'" class="ng-scope">' +
                            '<td>' +
                                '<img class="rec-thumb-image" ng-src="{{image.imageObject}}" alt="company profile picture" />' +
                            '</td>' +    
                            '<td>{{image.name}}</td>' + 
                            '<td>{{image.size}} MB</td>' + 
                            '<td>' + 
                                '<span class="img-btn" ng-click="removeImage($index)">' +
                                    '<i class="my-glyphicon my-glyphicon-remove"></i>' +
                                '</span>' +
                            '</td>' + 
                        '</tr>' +
                    '</tbody>' +
                 '</table>'
                 ,
        link: function (scope, element, attributes, controller) {
            scope.removeImage = function () {
                var removeImage = this.image;

                this.$parent.uploadedImages = this.$parent.uploadedImages.filter(function (item) {
                    return item.name !== removeImage.name;
                });

                if (this.$parent.uploadedImages.length == 0)
                    this.$parent.uploadedImages = null;
            }

            scope.browseImage = function () {
                angular.element('#' + attributes.fileUploader).trigger('click');
            }
        }
    }; //return

});

