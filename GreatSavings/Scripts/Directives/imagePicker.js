bizModule.directive('imagePicker', function ($q) {

    return {
      
        scope: {
            uploadedImage: '=uploadedImage',
            fileuploader:'@fileUploader'
        },
        template:
            '<a id="comp-image-link" class="change_picture_link"  href="" ng-click="browseImage()"  >' +
                                '<img id="comp-image" ng-src="{{!uploadedImage ? \'..//Images//noImgPurple256.png\' : uploadedImage.imageObject}}" width="300" alt="company profile picture" />' +
                                '<span class="change_picture">' +  
                                    '<span class="icon"></span>Browse Picture' + 
                                '</span>' + 
                            '</a>' + 
                            '<div class="img-uploaded" ng-show="!!uploadedImage"  >' + 
                                '<div class="img-uploaded-desc">' + 
                                    '<span class="img-uploaded-name">' + 
                                        'File: {{uploadedImage.name}} ' + 
                                    '</span>' + 
                                    '<span class="img-uploaded-size">' + 
                                        'Size: {{uploadedImage.size}} MB' + 
                                    '</span>' + 
                                '</div>' + 
                            '</div>',
        link: function (scope, element, attributes, controller) {
            scope.browseImage = function () {
                angular.element('#' + attributes.fileUploader).trigger('click');
            }
        }
    }; //return

});