# EvolentHealthExerciseCode

#Contact Management System
--------------------------------------------------------------------
## Description :-

	By this product manage basic contact details of a person / client  for a organization. 

----------------------------------------------------------------------------------------------------	
## Project Folder Structure :-

	1)	ClientApp
	2)	EvolentHealthExercise
	3)	PublishAPI
	
	1)	ClientApp
		This folder is use for client side UI page(s) and resources. 
		
		### Folder Structure
		ClientApp---
		-----------Script
		-----------Style
	
	2)	EvolentHealthExercise
		This folder is use for server side API projects & resources. 
		
		### Folder Structure
		EvolentHealthExercise---
		-----------------------EvolentHealthExerciseProject
		------------------------------EvolentHealthBusinessLayer
		------------------------------EvolentHealthDataAccessLayer
		------------------------------EvolentHealthDataModel
		------------------------------EvolentHealthExerciseApi
		------------------------------EvolentHealthExerciseApi.Tests
		------------------------------packages
		
	3)	PublishAPI
		This folder contain the publish resources of API project for deployment at IIS.
		
-----------------------------------------------------------------------------------------------------
## How to deploy API at IIS 

	1) Add a Site / Application 
	2) Set a alias name
	3) Set physical path of "PublishAPI" folder.
	4) Set web.config connection string settings as per your SQL Server credentials.
	
	Now it ready for use.

## How to deploy Client UI at IIS

	1) Add a Site / Application 
	2) Set a alias name
	3) Set physical path of "ClientApp" folder. 
	4) Edit "pageScript.js" file under "Script" folder of "ClientApp" folder, and set your API host URL at variable name "host".
	
	Now it ready for use.
	
------------------------------------------------------------------------------------------------------
## Database :
	
	"EvolentHealthDB.mdf" file present at App_Data folder. 
	
------------------------------------------------------------------------------------------------------

########################### DEMO #########################

###Client URL : 

		1)	http://13.71.49.131:3407/health/home/




###API URL : 

		1)	http://13.71.49.131:3407/health/api/GetContacts  
		2)	http://13.71.49.131:3407/health/api/GetContactById/1
		3)	http://13.71.49.131:3407/health/api/AddContact
		4)	http://13.71.49.131:3407/health/api/EditContact
		5)	http://13.71.49.131:3407/health/api/DeleteContact/10


		
---------------------------------------------------------------------------------------------------------


















		