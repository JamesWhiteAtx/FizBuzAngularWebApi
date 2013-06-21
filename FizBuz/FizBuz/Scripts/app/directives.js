'use strict';
/* http://docs-next.angularjs.org/api/angular.module.ng.$compileProvider.directive */

angular.module('fizbuz.directives', [])
    .directive('focusIt', function ($timeout) {
        return {
            scope: false,
            link: function (scope, element, attrs) {
                var trigger = attrs['focusIt'];
                if (trigger) {
                    scope.$watch(trigger, function (value) {
                        if (value === true) {
                            element[0].focus();
                            scope.trigger = false;
                        }
                    });
                };
            }
        };
    })


;
