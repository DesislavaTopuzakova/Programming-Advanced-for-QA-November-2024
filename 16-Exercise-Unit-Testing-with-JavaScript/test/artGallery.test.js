import { artGallery } from "../05-Art-Gallery/artGallery.js";
import { expect } from "chai";

describe('05.ArtGallery_Tests', () => {
    describe('Test function addArtwork', () => {
        it('It title is not a string return error with message "Invalid Information!"', () => {
            expect(() => artGallery.addArtwork(42, '20 x 30', 'Monet')).to.throw("Invalid Information!")
        });

        it('It artist is not a string return error with message "Invalid Information!"', () => {
            expect(() => artGallery.addArtwork('Woman with umbrella', '20 x 30', 42)).to.throw("Invalid Information!")
        });

        it('It dimension is not valid string return error with message "Invalid Dimensions!"', () => {
            expect(() => artGallery.addArtwork('Woman with umbrella', '20x30', 'Monet')).to.throw("Invalid Dimensions!")
            expect(() => artGallery.addArtwork('Woman with umbrella', 'a20 x 30', 'Monet')).to.throw("Invalid Dimensions!")
            expect(() => artGallery.addArtwork('Woman with umbrella', 42, 'Monet')).to.throw("Invalid Dimensions!")
        });

        it('It artist is not a valid return error with message "This artist is not allowed in the gallery!"', () => {
            expect(() => artGallery.addArtwork('Woman with umbrella', '20 x 30', 'V.D.Maistora')).to.throw("This artist is not allowed in the gallery!")
        });

        it('If all parameters are valid return properly message', () => {
            let expectedMessage = "Artwork added successfully: 'Woman with umbrella' by Monet with dimensions 50 x 70."
            expect(artGallery.addArtwork('Woman with umbrella', '50 x 70', 'Monet')).to.equal(expectedMessage)
        });
    });

    describe('Test function calculateCosts', () => {
        it('If exhibitionCosts is not a number throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.calculateCosts('a', 10, true)).to.throw("Invalid Information!")
        });
        it('If insuranceCosts is not a number throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.calculateCosts(10, 'a', true)).to.throw("Invalid Information!")
        });
        it('If sponsor is not a boolen throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.calculateCosts(100, 10, 'a')).to.throw("Invalid Information!")
        });
        it('If exhibitionCosts is a negative number throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.calculateCosts(-100, 10, true)).to.throw("Invalid Information!")
        });
        it('If insuranceCosts is a negative number throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.calculateCosts(100, -10, true)).to.throw("Invalid Information!")
        });
        it('If sponsor is true return expected message', () => {
            let expectedMessage = 'Exhibition and insurance costs are 180$, reduced by 10% with the help of a donation from your sponsor.'
            expect(artGallery.calculateCosts(180, 20, true)).to.equal(expectedMessage)
        });
        it('If sponsor is false return expected message', () => {
            let expectedMessage = 'Exhibition and insurance costs are 200$.'
            expect(artGallery.calculateCosts(180, 20, false)).to.equal(expectedMessage)
        });
    });
    describe('Test function organizeExhibits ', () => {
        it('If artworksCount is not a number throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.organizeExhibits('a', 10)).to.throw("Invalid Information!")
        });
        it('If displaySpacesCount is not a number throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.organizeExhibits(10, 'a')).to.throw("Invalid Information!")
        });
        it('If artworksCount is below or equal to zero throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.organizeExhibits(-10, 10)).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(0, 10)).to.throw("Invalid Information!")
        });
        it('If displaySpacesCount is below or equal to zero throw error with message "Invalid Information!"', () => {
            expect(() => artGallery.organizeExhibits(10, -10)).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(10, 0)).to.throw("Invalid Information!")
        });
        it('If artworksPerSpace is below 5 return expected message', () => {
            let expectedMessage = 'There are only 2 artworks in each display space, you can add more artworks.'
            expect(artGallery.organizeExhibits(12,5)).to.equal(expectedMessage)
        });
        it('If artworksPerSpace is equal to 5 return expected message', () => {
            let expectedMessage = 'You have 4 display spaces with 5 artworks in each space.'
            expect(artGallery.organizeExhibits(23,4)).to.equal(expectedMessage)
        });
        it('If artworksPerSpace is greater than 5 return expected message', () => {
            let expectedMessage = 'You have 4 display spaces with 8 artworks in each space.'
            expect(artGallery.organizeExhibits(33,4)).to.equal(expectedMessage)
        });
    });
});