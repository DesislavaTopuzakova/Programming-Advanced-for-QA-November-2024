import { isOddOrEven } from "../01-Even-or-Odd/isOddOrEven.js";
import { expect } from "chai";

describe('01.EvenOrOdd_Tests', () => {
    it('Shout return udefined if parameter is not a string', () => {
        expect(isOddOrEven(42)).to.undefined
        expect(isOddOrEven(null)).to.undefined
        expect(isOddOrEven(undefined)).to.undefined
    });

    it('Shoud return even if parameter string length is even', () => {
        expect(isOddOrEven('Hello!')).to.equal('even')
        expect(isOddOrEven('Hi')).to.equal('even')
    });

    it('Shoud return odd if parameter string length is odd', () => {
        expect(isOddOrEven('Diyan')).to.equal('odd')
        expect(isOddOrEven('a')).to.equal('odd')
    });
});