Steps to load test data in to database:

1) Start the Mongo server and open mongo shell:
In cmd go to mongoDB bin files and run mongod.exe and mongo.exe

2) Create the database
command : use test

3) Import the provided JSON files:
Command : mongoimport --db dbName --collection collectionName --file fileName.json --jsonArray

4) To view, the collections use the following command 
command : db.getCollection('collectionName').find().pretty()