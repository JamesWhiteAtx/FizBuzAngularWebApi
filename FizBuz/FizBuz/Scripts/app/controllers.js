'use strict';
/* App Controllers */

fizbuz
.controller('FizBuzCtrl', ['$scope', '$location', 'FizBuzzer', function ($scope, $location, FizBuzzer) {
    $scope.config = {
        from: 1,
        thru: 10,
        evals: []
    };
    $scope.list = [];

    $scope.removeEval = function (idx) {
        $scope.config.evals.splice(idx, 1);
    };

    $scope.addEval = function (d, t, focus) {
        $scope.config.evals.push({ denom: d, token: t, shouldFocus: focus });
    }

    $scope.addToList = function (t) {
        $scope.list.push({ token: t });
    }

    $scope.genList = function () {
        var e = $.param($scope.config.evals);
        var denoms = [];
        var tokens = [];
        $.each($scope.config.evals, function (index, value) {
            denoms.push(value.denom);
            tokens.push(value.token);
        });

        FizBuzzer.get(
            { from: $scope.config.from, thru: $scope.config.thru, denoms: denoms, tokens: tokens },
            function (data, status, headers, config) {
                $scope.list = data.Results;
            },
            function (data, status, headers, config) {
            }
        );
    }

    $scope.$watch('config.from', function (newVal, oldVal) {
        if (angular.isNumber(newVal)) {
            if ($scope.config.thru <= $scope.config.from) {
                $scope.config.thru = $scope.config.from + 1;
            }
        } else {
            $scope.config.from = oldVal;
        }
    });

    $scope.$watch('config.thru', function (newVal, oldVal) {
        if (angular.isNumber(newVal)) {
            if ($scope.config.thru <= $scope.config.from) {
                $scope.config.from = $scope.config.thru - 1;
            }
        } else {
            $scope.config.thru = oldVal;
        }
    });

    $scope.$watch('config.evals', function (newVal, oldVal) {
        var x = newVal;
    }, true);

    $scope.addEval(3, "Fiz");
    $scope.addEval(5, "Buz");

} ])
;
