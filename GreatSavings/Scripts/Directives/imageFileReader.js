bizModule.directive('imageFileReader', function ($q) {
    /*
    made by elmerbulthuis@gmail.com WTFPL licensed
    */
    var slice = Array.prototype.slice;


    return {
        restrict: 'AE',
        require: '?ngModel',
        scope: {
            selectedImage: '=selectedImage',
        },
        //template: "Image Name: {{imagefilename}}",
        link: function (scope, element, attrs, ngModel) {
            if (!ngModel) return;

            ngModel.$render = function () { }

            element.bind('change', function (e) {
                var element = e.target;
                if (!element.value) return;

                element.disabled = true;
                $q.all(slice.call(element.files, 0).map(readFile))
                  .then(function (values) {
                      if (element.multiple)
                          ngModel.$setViewValue(values);
                      else
                          ngModel.$setViewValue(values.length ? values[0] : null);
                      element.value = null;
                      element.disabled = false;
                  });

                function readFile(file) {
                    var deferred = $q.defer();
                    var uploadedImage = {};
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        uploadedImage.name = file.name;
                        uploadedImage.size = (file.size / 1024 / 1024).toFixed(2);
                        uploadedImage.imageObject = e.target.result;

                        scope.$apply(function () {
                            scope.selectedImage = uploadedImage.imageObject.replace(/data:image\/jpeg;base64,/g, '');
                        });

                        deferred.resolve(uploadedImage);
                        //deferred.resolve(e.target.result);
                    }
                    reader.onerror = function (e) {
                        deferred.reject(e);
                    }
                    reader.readAsDataURL(file);

                    return deferred.promise;
                }

            }); //change

        } //link

    }; //return

}); //appFilereader
