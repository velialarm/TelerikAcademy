define(['main','mocha'], function (appModule, mocha) {

    mocha.setup();
    describe("#appModule", function () {

        it("GetMessage function works correct", function (done) {
            var expected = 2;
            console.log("testing...");
//            appModule.getData("http://url.com", function (data, statusText, xhr) {
//                var expectedTextStatus = 'success';
//                returnedStatus = (xhr.status / 100) | 0;
//                expect(statusText).to.deep.equal(expectedTextStatus);
//                expect(expected).to.deep.equal(returnedStatus);
//                done();
//            })
        });
    });
});