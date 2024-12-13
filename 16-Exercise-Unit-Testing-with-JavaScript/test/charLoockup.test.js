import { lookupChar } from "../02-Char-Loockup/charLoockup.js";
import { expect } from "chai";

describe('02.CharLoockup_Tests', () => {
    it('Shoud retirn undefined if first parameter is not a string', () => {
        expect(lookupChar(42, 2)).to.undefined
    });

    it('Shoud retirn undefined if second parameter is not a number', () => {
        expect(lookupChar('text', 'a')).to.undefined
    });

    it('Shoud retirn undefined if second parameter is a floating point number', () => {
        expect(lookupChar('text', 3.5)).to.undefined
    });

    it('Shoud return "Incorrect index" if index is greater than string length', () => {
        expect(lookupChar('Hello', 7)).to.equal("Incorrect index")
    });

    it('Shoud return "Incorrect index" if index is equal to string length', () => {
        expect(lookupChar('Hello', 5)).to.equal("Incorrect index")
    });

    it('Shoud return "Incorrect index" if index is below zero', () => {
        expect(lookupChar('Hello', -7)).to.equal("Incorrect index")
    });

    it('Shour return specific character if parameters are correct', () => {
        expect(lookupChar('Hello', 0)).to.equal('H')
        expect(lookupChar('Hello', 1)).to.equal('e')
        expect(lookupChar('Hello', 4)).to.equal('o')
    });
});