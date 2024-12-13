import { mathEnforcer } from "../03-Math-Enforcer/marthEnforcer.js";
import { assert } from "chai";

describe('03.MathEnforcer_Tests', () => {
    describe('Test function addFive', () => {
        it('Shoud return undefined if parameter is not a number', () => {
            assert.isUndefined(mathEnforcer.addFive('a'))
            assert.isUndefined(mathEnforcer.addFive(null))
            assert.isUndefined(mathEnforcer.addFive(undefined))
        });

        it('If parameter is a positive number shoud add five to parameter and return the result', () => {
            assert.equal(mathEnforcer.addFive(5), 10)
        });

        it('If parameter is a negative number shoud add five to parameter and return the result', () => {
            assert.equal(mathEnforcer.addFive(-5), 0)
        });

        it('If parameter is a floating-point number shoud add five to parameter and return the result', () => {
            assert.closeTo(mathEnforcer.addFive(3.14), 8.14, 0.01)
        });
    });
    describe('Test function subtractTen', () => {
        it('Shoud return undefined if parameter is not a number', () => {
            assert.isUndefined(mathEnforcer.subtractTen('a'))
            assert.isUndefined(mathEnforcer.subtractTen(null))
            assert.isUndefined(mathEnforcer.subtractTen(undefined))
        });

        it('If parameter is a positive number shoud subtract ten from parameter and return the result', () => {
            assert.equal(mathEnforcer.subtractTen(15), 5)
        });

        it('If parameter is a negative number shoud subtract ten from parameter and return the result', () => {
            assert.equal(mathEnforcer.subtractTen(-15), -25)
        });

        it('If parameter is a floating-point number shoud subtract ten from parameter and return the result', () => {
            assert.closeTo(mathEnforcer.subtractTen(15.48), 5.48, 0.01)
        });
    });
    describe('Test function sum', () => {
        it('Shoud return undefined if firs parameter is not a number', () => {
            assert.isUndefined(mathEnforcer.sum('a', 42))
        });

        it('Shoud return undefined if second parameter is not a number', () => {
            assert.isUndefined(mathEnforcer.sum(42, 'a'))
        });

        it('If two parameters are positive numbers shoud return sum of it', () => {
            assert.equal(mathEnforcer.sum(42, 8), 50)
        })

        it('If two parameters are negative numbers shoud return sum of it', () => {
            assert.equal(mathEnforcer.sum(-2, -8), -10)
        })

        it('If two parameters are floting-point numbers shoud return sum of it', () => {
            assert.closeTo(mathEnforcer.sum(3.14, 4.52), 7.66, 0.01)
        })
    });
});