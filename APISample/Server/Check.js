 module.exports.post = function (request, response) {
     
     
        var query = {
            sql: 'Select * from TestTable where Name = @completed ORDER by createdAt',
            parameters: [
                { name: 'completed', value: request.query.Name }
            ],
                      
        };

        request.azureMobile.data.execute(query)
            .then(function (results) {
               response.setHeader('Content-Type', 'application/json');
                response.status(200).send(JSON.stringify(results));
            });
 };

