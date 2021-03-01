# BlueTooth-ASP.NET-Core-3.1-Entity-Framework-Code-First-Approach

Subject name: System analysis and design, University of Zenica - Software engineering, 4th semester
Project name: Analysis, design & implementation of dental healthcare system
Project start date: 01.03.2020
Project end date: 01.06.2020

Summary
With development of technology came significant changes in every aspect of people’s lives.
Primarily, in today’s society the main focus is on web and mobile applications which have been
designed in a way that makes our lives easier. These applications provide fast and easy access for their
users and easy problem and task solving. With this in mind, emerged the need for a Dental cloud
application which would be used by private dental practices and their patients. The authors’ proposal
on this problem is the Bluetooth application which would provide easy and simple management of
staff, invoices, materials and equipment used in an appointment as well as patient management. One
of many functionalities that Bluetooth comes with is detailed insight into the history of dental
illnesses of every patient that has been registered on the system through eDentalRecord module. In
this paper, authors’ goal is to show in great detail advantages and disadvantages as well as
functionalities of our solution proposal. Throughout history human kind yearned for the better and
have always tried their best to develop some tool or mechanism that would make their lives and work
easier, so we tried to follow our primary instinct and continue our tendencies by creating this
application.


1. Problem Description
A common problem for people with any kind of health issues around the globe is reaching and
contacting their health care providers (family doctor, dentist, nurse, technician..) , booking their
appointments due to a big influx of patients, and of course spending hours in the waiting room in front
of the doctors office. It is also difficult to keep track and have a clear insight into your own medical
record and the history of your diagnosis because of the excessive paperwork. As previously
mentioned, we have decided to resolve these problems on a dental medicine (dentistry) example.
Dental industry is growing rapidly and thus you can see more and more privatized dental practises
opening day by day. Every dental office, privatized or not, has a large scaled set of patients and that
implies a problem for both the medical staff and the patients. Patients are in need of an easier way to
book their appointments, stay connected with their doctors, have their dental record and keep track of
their payments to the dental office. The dental office on the other hand is in need of an easier way to
keep track of their patients, their diagnosis, payments, debts and many more.
Another issue that occurs for the dental office is their business and communicating with their external
associates, mainly with their suppliers. An inevitable solution for resolving these problems and
making life easier for patients and business easier for medical staff will be demonstrated in the
following chapters.


2. Problem Solution
Given the described problem that the dental health system has been facing for many years, below we
will present you with a conceptual solution that will not only solve the described problem, but also
raise the level of the dental health system. The application should cover all business aspects of private
dental practices as well as their external associates. Users of the application will have the opportunity
to access it both through the mobile application and through their favorite web browser. The aim of
the application is to create a unique eCard of the patient, where it is expected to enter personal data
and history of dental diseases in order to gain better insight into the health status of the patient. The
user will be provided with the possibility of online appointments, evaluation of professional staff and
the possibility of card payment is included. In addition to the already mentioned possibilities, the user
of the service will have reminders on their profile for their scheduled appointments, where there will
also be the possibility of canceling the desired appointment no later than 24 hours before the
scheduled appointment. The dentist, who is also a user of the application, will have a view of the
schedule on a weekly basis and details of each appointment. They will be able to assign
responsibilities to assistants and have an overview of their responsibilities. They will also have the

ability to make diagnoses as well as a list of employees. During the analysis and design, our team
identified 3 main functional modules, which are:

1) eCard module
The primary goal of the eCard module, which will be available at the national level, is both to
more efficiently organize health records and to reduce the time patients spend in waiting
rooms. It is necessary to provide a unique data repository for patients with a comprehensive
view of their dental health. The patient has a detailed insight into the history of dental
diseases, the price list and the services it provides dental clinic. The medical staff of the dental
practice also has access to eCard module. eCard module also offers an online appointment
scheduling feature. When scheduling an examination, the patient is required to fill out a form
in which specifies the date and time of the desired inspection.
2) eWorker module
The main goal of the eWorker module is to better organize work responsibilities within a
dental practice. The users of the eWorker module are employees of the dental practice, each
of whom has a unique username and password. Employees include the owner of the dental
practice (manager), dentists, medical assistants and administrative staff.

3) eMaterial module
The eMaterial module is intended for the owner of a dental clinic. The whole process of
procurement of consumables requires certain procedures before the cooperation between the
owner of the practice and the supplier of equipment. The task of the owner of the dental office
is to know exactly what material he needs and in what quantities, and to know where he can
look for these funds. If the owner is a dentist, he will do it himself, and if he is only the owner
of the office, he will consult with the main employed dentist regarding the details. The owner
of the dental practice is expected to know in advance what material he needs to order.
The implementation of the solution is planned with the help of S.O.L.I.D, DRY, KISS and YAGNI
design principles that allow scalability and robustness of the application, and independent testing of
each module. Flexibility when migrating a database is also ensured by using repository pattern, and by
using CQRS principle we are able to achieve the most optimal system performance.
