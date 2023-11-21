# Library-Management-System-Using-C-Hash-and-Asp.Net


LIBRARY MANEGMENT SYSTEM.

1	INTRODUCTION:
A Library Management System is a software solution designed to manage and organize the operations of a library. It automates various tasks involved in library management, such as cataloging books, tracking inventory, issuing and returning books, managing member records, and generating reports. An ASP.NET Web Application provides a robust and scalable platform to develop such a system, allowing users to access it through a web browser.
The Library Management System using ASP.NET Web Application is designed to streamline the day-to-day activities of a library, making it easier for librarians and staff to manage the library's resources efficiently. The system provides a user-friendly interface for both librarians and library members, allowing them to perform various tasks with ease.
Key Features:
I have used theme with bootstrap so that this website will looks like 100% responsive and also we can easily understand
Student 
(1) student can register, we will add captcha in registration, after registration student account will be activated after verified by librarian. 
(2) student can login / forget password for forget password we will send email with link and using that link student can add new password. 
(3) student can update their profile / student can change password. 
(4) student can search book and student can download pdf and video if available. 
(5) student can see their taken book with details like books submission date, book issue dates, penalty etc. 
(6) student will get notification if librarian send any message. 
(7) student can give reply of librarian message 
(8) logout librarian
Admin 
(1) librarian can login 
(2) librarian can add new book details with pdf and mp4 if available then. 
(3) librarian can edit book details
 (4) librarian can delete book details 
(5) librarian can verify student details and approve student account and block student account. 
(6) librarian can issue books to students 
(7) librarian can add return books in stocks means student books return functionalities 
(8) librarian can see all books with stocks. 
(9) librarian can search books 
(10) librarian can search students 
(11) librarian can see that how many students have books right now. 
(12) librarian can send message to student regarding their books pending so student can see notification. 
(13) librarian can find books as per publication name or author name 
(14) librarian can set per day penalty example if librarian set penalty per day and student submit book 10 days after submission date then student have to pay penalty * 10. 
(15) logout.

 
2	STEP-BY-STEP EXPLANATION
Here is the detailed explanation of the code how the website works:
1	OUR PROJECT CONSIST OF TWO MAIN MASTER PAGES LIBRARIAN AND STUDENT WHICH ARE CONNECTED TO DIFFERENT WEB PAGES FOR DIFFERENT FUNCTIONALITIES. FIRSTLY, WE RUN THE PROGRAM AND THE HOMEPAGE WILL APPEAR WHERE WILL BE ABLE TO LOGIN AS A USER OR ADMIN(LIBRARIAN). STARTING WITH THE ADMIN AFTER CLICKING ON LOGIN AS ADMIN WILL APPEAR A LOGIN PAGE PANEL WE WILL SEE TWO TEXT BOXES FOR USERNAME AND PASSWORD. IF THE USERNAME AND PASSWORD FIELD IS EMPTY IT WONT LOGIN AND WILL GIVE AN ERROR MESSAGE. IF THE PASSWORD OR USERNAME IS INCORRECT WILL ALSO GIVE THE ERROR MESSAGE.

 
 
2	THERE IS ALSO A CAPTCHA TEXT FOR SECURITY REASONS IF THE CAPTCHA TEXT DOESN’T NOT MATCHES THE TEXT IN TEXTBOX, THEN IT WILL GIVE AN ERROR MESSAGE WRONG CAPTCHA AND WONT LOGIN.
 
3	AFTER THE ADMIN HAS SUCCESSFULLY LOGGED IN WE WILL SE THE MAIN PAGE OF CITY LIBRARY DASHBOARD PAGE. ON THE RIGHT HAND SIDE, WE WILL SEE THE NAME CARD OF THE ADMIN USER WHICH DISPLAYS THAT  ITS ADMIN AND ITS USERNAME AND IMAGE ON THE TOP WE WILL SEE NOTIFICATION PANEL AND ON THE LEFT HAND SIDE WE WILL SEE SIDE PANEL LIBRARIAN PANEL WHICH DISPLAYS ALL THE FUNCTIONALITIES.
 
4	IN THE LIBRARIAN PANEL WE CAN SEE FIRST OPTION AS BOOKS. UNDER THE BOOKS OPTION IS A DISPLAY BOOKS OPTION WHICH DISPLAYS ALL THE AVAILABLE BOOKS. IN THE AVAILABLE BOOKS PAGE WE WILL SEE BOOK IMAGE, NAME, AUTHOR OF BOOK, ISBN NUMBER AND OTHER IMPORTANT DETAILS RELATED TO THE BOOK. THERE ARE TWO OPTIONS FOR THE ADMIN TO EDIT BOOKS ARE DELETE A SPECIFIC BOOK INFORMATION COMPLETELY FROM DATABASE AND DISPLAY. 
 
5	AS OUR PROJECT IS CONNECTED TO DATABASE USING THE CONNECTION STRING. IN THE ADD BOOKS PAGE ADMIN CAN ADD A NEW BOOK. IF IN THE ADD BOOK PROCESS INSERTION FIELDS ARE EMPTY IT WONT ADD A NEW BOOK UNTIL THE INFORMATION IS BEEN GIVEN EXCEPT FROM BOOK PDF AND VIDEO WHICH IS NOY COMPULSORY TO BE ADDED. AFTER YOU HAVE SUCCESSFULLY ADDED THE NEW BOOK YOU WILL RECEIVE A BOOK SUCCESSFULLY ADDED NOTIFICATION.
 
 
 
 
6	IN THE LIBRARIAN PANEL NEXT YOU WILL SEE STUDENTS WHICH HAS THE INFORMATION OF ALL THE REGISTERED STUDENTS. THERE ARE THREE OPTIONS FOR ADMIN WHETHER HE ADMINS WANTS TO DELETE A CERTAIN USER FROM THE LIST OR IF A NEW USER HAS REGISTERED INITIALLY HIS ACCOUNT IS NOT ACTIVATED UNTIL THE ADMIN HAS APPROVED SO THERE IS AN OPTION FOR ACTIVATE AND DEACTIVATE USER.
   
 
7	NEXT WE WILL SEE AN OPTION OF PENALTY WHERE ADMIN CAN SET AMOUNT OF PENALTY PER DAY FOR USER BEING LATE IN RETURNING THE BOOK ON TIME THE FORMULA IS = LATE DAYS * PENALTY SET. 
 
8	IN THE NEXT STEP IN PANEL, WE WILL SEE AN OPTION FOR ISSUE BOOKS WHICH IS USED TO GET BOOKS OR LEND BOOKS TO USER. IN GET BOOK PAGE WE FIRST THE ADMIN HAS TO ENTER THE ENROLLMENT NO OF THE STUDENT WHO WANTS TO BORROW THE BOOK AND THEN SELECT THE ISBN NO OF THE BOOK WHICH THE STUDENTS WANTS. AS THE ADMIN SELECTS THE REQUIRED ISBN OF BOOK THE BOOK WILL BE DISPLAYED UNDER WITH THE IMAGE OF BOOK, NAME AND QUANTITY. IF THE ADMIN DOESN’T SELECT ISBN NO OR ENROLLMENT NO BY ACCIDENT, HE WON’T BE ABLE TO LEND BOOK AND WILL RECEIVE A MESSAGE TO SELECT THE INFORMATION. ALSO, IF THAT USER HAS ALREADY BORROWED THE SAME BOOK WON’T BE ALLOWED TO BORROW AGAIN AND WILL RECEIVE A MESSAGE THAT BOOK HAS ALREADY BEEN BORROWED TO YOU BEFORE. AS THE ADMIN HAS SUCCESSFULLY LEND THE BOOK YOU WILL RECEIVE A SUCCESS MESSAGE AND NO OF AVAILABLE BOOKS WE BE DECREASED BY ONE TIME BECAUSE ONE BOOK IS BEEN LEND TO A STUDENT. 
 
 
9	NEXT WE WILL SEE RETURN BOOKS OPTION TO RETURN LEND BOOKS. ALSO WE ADDED PAGINATION AND SEARCH OPTION IN EVERY PAGE WITH DATA LIST. IF THE ADMIN WANTS TO SEARCH A SPECIFIC USER HE CAN JUST SEARCH HIS NAME. THE FUNCTIONALITIES ARE ADDED USING MODERN BOOTSTRAP WHICH IS SUPER RESPONSIVE. THERE IS AN OPTION TO RETURN BOOK IF THERE IS ANY PENALTY ON USER HE/SHE HAS TO PAY IT FIRST TO RETURN THE BOOK.
   
10	NEXT I ADDED A FUNCTIONALITY OF REAL TIME CHAT. USER AND ADMIN AND CHAT WITH EACH OTHER. IF THE USER HASN’T RETURNED THE BOOK THE ADMIN CAN SEND A MESSAGE TO HIM BY USING CHAT OPTION. IF THE USERS ARE OFFLINE THE MESSAGE WILL BE SENT THEY CAN CHECK WHEN THEY WILL BE ONLINE AND WILL SEE A NOTIFICATION IN NOTIFICATION PANEL. 
 
 
11	LAST THERE IS A FUNCTIONALITY FOR ADMIN TO LOGOUT OF THE CITY LIBRARY. CAN ALSO LOGOUT FROM THE DROPDOWN MENU IN THE PROFILE IMAGE. THE SESSION CAN SUCCESSFULLY LOGOUT. 
 
12	NOW STARTING WITH THE STUDENT PANEL GO TO THE HOMEPAGE AND WE WILL SEE OPTION TO LOGIN AS USER ON THE LOGIN PAGE WE WILL SEE SAME TWO TEXT BOXES TO FILL IN THE INFO OF USERNAME AND PASSWORD AND CAPTCHA IS REQUIRED FOR SECURITY. IF THERE IS A NEW USER WHO WANTS TO REGISTER THERE IS AN OPTION TO REGISTER. STUDENTS IS TO FILL HIS INFORMATION. AND THEN CONFIRM THAT HE IS NOT BOT BY COMPLETING THE FUNCTIONALITY OF RECAPTCHA . AFTER YOU HAVE SUCCESSFULLY REGISTERED YOU HAVE TO WAIT UNTIL THE ADMIN APPROVES YOU AND THEN YOU CAN LOGIN. 
 
 
13	AFTER LOGGING IN SUCCESSFULLY WE WILL SEE THE MAIN PAGE DISPLAY WHICH HAS A NAME CARD OF THE STUDENT IN CENTER AND ON LEFT HAND SIDE IS STUDENT PANEL WHERE ARE SOME FUNCTIONALITIES. 
14	IN THE STUDENT PANEL WE WILL SEE BOOKS OPTION WHICH IS TO DISPLAY ALL THE AVAILABLE BOOKS IN LIBRARY WHICH A STUDENT CAN BORROW. THERE IS ALSO OPTION TO DISPLAY PDF AND VIDEOS OF BOOKS. THE STUDENT CAN ALSO SEARCH A SPECIFIC BOOK IN THE SEARCH BAR. 
15	NEXT OPTION IS OF MY ISSUED BOOKS WHICH IS TO DISPLAY THE BOOKS THAT ARE BEING BORROWED AND PREVIOUS RECORD OF BOOKS BORROWED. HERE THE STUDENT CAN ALSO SEE THE LATE DAYS AND PENALTY FOR HOW MUCH HE HAS TO PAY FOR LATE DAYS.  
16	NEXT IS THE REAL TIME CHAT WITH THE ADMIN FOR CUSTOMER SERVICES AND INFORMATION. YOU CAN CHAT WITH ADMIN AND CAN ASK ANYTHING. 
17	AND THE LAST OPTION IS TO LOGOUT FROM STUDENT PANEL. 
 
3	PURPOSE
By implementing a Library Management System using ASP.NET Web Application, libraries can improve efficiency, enhance user experience, and ensure accurate management of library resources. It simplifies administrative tasks, reduces paperwork, and provides valuable insights through reports and analytics, ultimately enhancing the overall library experience for both librarians and users.



