'use strict';

angular.module('fizbuz.services', ['ngResource'])
    .value('version', '0.1')

    .factory('FizBuzzer', ['$resource', function ($resource) {
         return $resource('/api/fizbuz', {}

        );
    } ])

;
