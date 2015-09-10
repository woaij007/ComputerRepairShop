#Small Business Management System    


##Purpose:
You’ve been hired by the owner of a local computer repair shop to build a web site to support his business.  In this project you will construct a web site and associated Web API that support advertising the repair service, tracking repair progress and completion, sending completion notices via SMS messages, and, in a private part, tracking parts inventory, work status, and billing.

The owner also conducts, for advertising purposes, free monthly classes on computer use for non-technical people.  He wants the web site to announce upcoming classes and post information about time and place.

##Requirements:
The requirements for this Small Business Management System (SBMS) are to:
	
1.	Shall provide a home page that summarizes the company’s repair services and links to support pages with repair status for each job and a message facility were registered users can post questions and receive answers.
2.	Shall provide the home page and one or more pages, accessible to everyone, that describe the company repair services and upcoming free classes.  All other pages require registration for first access and login thereafter.
3.	Registered users shall see, and can access a status page for their job and a support page that allows the user to post questions and receive answers for current jobs and to request pickup and delivery.  This page will display a charge for pickup and delivery based on whether the user lives in the same area code or in an adjacent area code .  Users not living in an adjacent area code will be informed that pickup and delivery are not supported and provide information about using UPS to send their machines and the fee required for the shop to send back the repaired machine via UPS.
4.	The support page shall provide a problem report form with a place for problem description and email address.
5.	This web site shall provide a web API that supports creating billing and managing inventory from a WPF client when the user is authenticated as an employee.  
a.	It should be easy to add parts to an inventory database with fields for number ordered and number available at the business site.  
b.	It should also be easy to move any given number of ordered parts to the available list as those parts arrive.  
c.	When a bill is created the client should provide a selection list of parts, with prices, to add to the bill and automatically reduce the inventory counts as appropriate.  
d.	When a bill is created, the client will send an SMS message  to inform the user of the job completion.
e.	Finally, the service and client should support responding to questions from the support page and posting answers on that page.
6.	Please implement the public and private areas using Asp.Net MVC and implement the web service via Asp.Net Web API.
7.	Shall use, and demonstrate that you use, LINQtoXML and LINQtoSQL or Entity Framework
8.	Shall use, and demonstrate that you use, at least four of the following:
    a.	HTML5 features
	b.	Partial Views
	c.	Ajax
	d.	Client and Server validation
	e.	Roles
	f.	Entity Framework

