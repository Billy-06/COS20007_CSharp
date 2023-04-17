#include "QueryInterface.h"

QueryInterface::QueryInterface()
{
    // initialise 4 classrooms & add the to the appropriate list
    ClassRoom* classrm0 = new ClassRoom();
    ClassRoom* classrm1 = new ClassRoom();
    ClassRoom* classrm2 = new ClassRoom();
    ClassRoom* classrm3 = new ClassRoom();
    _classes.insert(_classes.begin(), classrm0);
    _classes.push_back(classrm1);
    _classes.push_back(classrm2);
    _classes.push_back(classrm3);

    classrm0->classNumber = 0020;
    classrm1->classNumber = 0021;
    classrm2->classNumber = 0022;
    classrm3->classNumber = 0023;


    // initialise 4 lecturers
    Lecturer* lec0 = new Lecturer( "Jackson", "Kanade", "pass000", 430 );
    Lecturer* lec1 = new Lecturer( "Lin", "Wee", "pass001", 431 );
    Lecturer* lec2 = new Lecturer( "Nick", "Kosa", "pass002", 432 );
    Lecturer* lec3 = new Lecturer( "Meng", "Joe", "pass003", 433 );

    // assign lecturers classes
    lec0->assignClass(classrm0);
    lec1->assignClass(classrm1);
    lec2->assignClass(classrm2);
    lec3->assignClass(classrm3);

    // add the lecturers to the appropriate list
    _lecturers.insert(_lecturers.begin(), lec0);
    _lecturers.push_back(lec1);
    _lecturers.push_back(lec2);
    _lecturers.push_back(lec3);

    // initialise 4 students & add them to the appropriate list
    Student* stud0 =  new Student("Prior", "Kish", "pass00", 340);
    Student* stud1 =  new Student("Lin", "Feng", "pass01", 341);
    Student* stud2 =  new Student("Micah", "Terk", "pass02", 342);
    Student* stud3 =  new Student("Ahmed", "Feng", "pass03", 343);

    stud0->setId(2000);
    stud1->setId(2001);
    stud2->setId(2002);
    stud3->setId(2003);

    _students.insert(_students.begin(), stud0);
    _students.push_back(stud1);
    _students.push_back(stud2);
    _students.push_back(stud3);

    // initialise 4 units
    Unit* unit0 = new Unit( 6786, "Object Oriented Programming", "Semester 2", "This course introduces the fundamemntals of Object Oriented Programming");
    Unit* unit1 = new Unit( 6787, "Web Development", "Semester 2", "This course introduces the fundamemntals of Web Development");
    Unit* unit2 = new Unit( 6788, "Artificial Intelligence", "Semester 2", "This course introduces the fundamemntals of Artificial Intelligence");
    Unit* unit3 = new Unit( 6789, "Machine Learning", "Semester 2", "This course introduces the fundamemntals of Machine Learning");

    // Add the units to the appropriate list
    _units.insert(_units.begin(), unit0);
    _units.push_back(unit1);
    _units.push_back(unit2);
    _units.push_back(unit3);

    // Give the class the unit
    classrm0->setUnit(unit0);
    classrm1->setUnit(unit1);
    classrm2->setUnit(unit2);
    classrm3->setUnit(unit3);

    // add students to classes
    classrm0->addStudent(stud0, lec0->getId());
    classrm1->addStudent(stud1, lec1->getId());
    classrm2->addStudent(stud2, lec2->getId());
    classrm3->addStudent(stud3, lec3->getId());


}
QueryInterface::~QueryInterface()
{
    // delete classes
    for_each(
        _classes.begin(),
        _classes.end(),
        [](ClassRoom* item) { delete item; }
    );

    //delete lecturers
    for_each(
        _lecturers.begin(),
        _lecturers.end(),
        [](Lecturer* item) { delete item; }
    );

    // delete students
    for_each(
        _students.begin(),
        _students.end(),
        [](Student* item) { delete item; }
    );

    // delete units
    for_each(
        _units.begin(),
        _units.end(),
        [](Unit* item) { delete item; }
    );

    // delete this object
    delete this;
}

string QueryInterface::getInput()
{
    string response;
    cin >> response;

    return response;
}

void QueryInterface::welcomePage()
{
    cout
        << "\n====================================="
        << "\n               WELCOME               "
        << "\n       STUDENT GRADING SYSTEM        "
        << "\n====================================="
        << "\nPlease select an option to continue"
        << "\n1. Log In (Student)"
        << "\n2. Log In (Lecturer)" << endl;

    string ans;

    ans = this->getInput();

    if (ans == "1") {
        string idStr;
        string passw;
        int idNum;

        cout << "Please enter your ID number" << endl;
        idStr = this->getInput();

        idNum = stoi(idStr);

        cout << "Please enter your password" << endl;
        passw = this->getInput();

        auto search = find_if(
            _students.begin(),
            _students.end(),
            [&idNum](Student* item){ return item->getId() == idNum; }
        );
        if (search != _students.end())
        {
            this->login(*search);
            this->studentHomepage(*search);
        }

    }
    if (ans == "2") {
        string idStr;
        string passw;
        int idNum;

        cout << "Please enter your ID number" << endl;
        idStr = this->getInput();

        idNum = stoi(idStr);

        cout << "Please enter your password" << endl;
        passw = this->getInput();

        auto search = find_if(
            _lecturers.begin(),
            _lecturers.end(),
            [&idNum](Lecturer* item){ return item->getId() == idNum; }
        );
        if (search != _lecturers.end())
        {
            this->login(*search);
            this->lecturerHomepage(*search);
        }

    }

}

void QueryInterface::login(User* item)
{
    item->logIn();
}

void QueryInterface::logout(User* item)
{
    item->logOut();

}

void QueryInterface::enroll(Student* stud, Unit* unit)
{
    Unit* copy = new Unit(*unit);
    stud->addUnit(copy);

    cout
        << "\n!!!!!!! SUCCESSFUL !!!!!!"
        << "\nEnrolled Successfully" << endl;

    this->studentHomepage(stud);
}

void QueryInterface::viewUnits()
{

    for_each(
        _units.begin(),
        _units.end(),
        [](Unit* item) { item->appPrint(); }
    );
}

void QueryInterface::studentHomepage(Student* stud)
{
    stud->logIn();
    if (stud->getStatus())
    {
        cout
            << "\n====================================="
            << "\n               WELCOME               "
            << "\n          STUDENT HOMEPAGE           "
            << "\n====================================="
            << endl;


        stud->print();

        string response = this->studentNavigation(stud);

        if (response == "1") {
            viewUnits();

            string ans;
            cout
                << "\nPlease enter the code of the unit you'd like to enroll to" << endl;
            cin >> ans;

            auto finder = find_if(
                        this->_units.begin(),
                        this->_units.end(),
                        [&ans](Unit* item) { return item->getCode() == stoi(ans); }
                    );

            if (finder != this->_units.end())
            {
                this->enroll(stud, *finder);
            }
            else {
                cout
                << "!!!!!!! FAILED !!!!!!"
                << "The enrollment was not successful" << endl;
            }

        }
        else if (response == "2")
        {
            this->viewUnits();
            cout << "\n" << endl;
            this->studentNavigation(stud);
        }
        else {
            this->welcomePage();
        }

    } else {
        cout
            << "\nYou are not Logged In"
            << "\nPlease make sure you log in first!\n\n" << endl;

        this->welcomePage();
    }

}

void QueryInterface::lecturerHomepage(Lecturer* lec)
{
    lec->logIn();
    if(lec->getStatus())
    {
        cout
        << "\n====================================="
        << "\n               WELCOME               "
        << "\n          LECTURER HOMEPAGE          "
        << "\n====================================="
        << "\nView Your classes below" <<endl;

        // if ( lec->getClassroom().size() > 0 )
        // {
        //     for_each(
        //         lec->getClassroom().begin(),
        //         lec->getClassroom().end(),
        //         [](ClassRoom* item) { item->print(); }
        //     );
        // }
        // else {
        // }

        for_each(
            _classes.begin(),
            _classes.end(),
            [](ClassRoom* item) { item->print(); }
        );

        string response = this->lecturerNavigation(lec);

        if (response == "1"){
            int code;
            string codeStr;
            for_each(
                _units.begin(),
                _units.end(),
                [](Unit* item) { item->appPrint(); }
            );
            cout << "\nPlease enter the code of the unit you'd like to edit" << endl;
            codeStr = this->getInput();
            code  = stoi(codeStr);

            auto search = find_if(
                _units.begin(),
                _units.end(),
                [&code](Unit* item) { return item->getCode() == code; }
            );

            this->editUnit(*search);
        }
        else if (response == "2") this->createUnit();
        else if (response == "3") this->updateResults(lec);
        else if (response == "4") this->logout(lec);

    } else {
        cout
            << "\nYou are not Logged In"
            << "\nPlease make sure you log in first!\n\n" << endl;

        this->welcomePage();
    }
}

string QueryInterface::studentNavigation(Student* stud)
{
    string answer;

    cout
        << "\n====================================="
        << "\n         STUDENT NAVIGATION          "
        << "\n====================================="
        << "\nPlease select an option to continue"
        << "\n1. Enroll"
        << "\n2. View Units"
        << "\n3. Log Out" << endl;

    cin >> answer;
    cout << endl;

    return answer;
}

string QueryInterface::lecturerNavigation(Lecturer* lec)
{
    string answer;

    cout
        << "\n====================================="
        << "\n         LECTURER NAVIGATION         "
        << "\n====================================="
        << "\nPlease select an option to continue"
        << "\n1. Edit Unit"
        << "\n2. Create Unit"
        << "\n3. Update Results"
        << "\n4. Log Out" << endl;

    cin >> answer;
    cout << endl;

    return answer;
}

void QueryInterface::createUnit()
{
    int code;
    string codeStr;
    string name;
    string sem;
    string desc;

    cout << "\nEnter the code you'd like to assign the Unit" << endl;
    codeStr = this->getInput();
    code = stoi(codeStr);

    cout << "\nEnter the name you'd like to assign the Unit" << endl;
    name = this->getInput();

    cout << "\nEnter the semester you'd like to avail the Unit" << endl;
    sem = this->getInput();

    cout << "\nEnter the description you'd like to assign the Unit" << endl;
    desc = this->getInput();

    Unit* newUnit = new Unit(code, name, sem, desc);

    _units.push_back(newUnit);

}

void QueryInterface::updateResults(Lecturer* lec)
{
    int classNum, studId, assmntScr;
    string classNumStr, idStr, grade, assmntStringScr, response, assmntName;

    for_each(
        lec->getClassroom().begin(),
        lec->getClassroom().end(),
        [](ClassRoom* item){ item->print(); }
    );

    cout << "\nPlease enter the class number in which to edit results" << endl;

    classNumStr = this->getInput();
    classNum = stoi(classNumStr);

    auto classFind = find_if(
        lec->getClassroom().begin(),
        lec->getClassroom().end(),
        [&classNum](ClassRoom* item) { return item->classNumber == classNum; }
    );
    if (classFind != lec->getClassroom().end())
    {
        cout << "\nPlease enter the student ID of the student whose results you'd like to post" << endl;
        idStr = this->getInput();
        studId = stoi(idStr);

        auto studFind = (*classFind)->getStudent(studId);

        cout << "\nWould you like to change the [1.] Assessment or [2.] Grade"
            << "\nSimply enter 1 or 2" << endl;

        response = this->getInput();
        if (response == "1") {

            cout << "\nWhich assessment would you like to update?"
                << "\nEnter the name of the assessment (case sensitive)" << endl;

            assmntName = this->getInput();

            auto findAssmnt = find_if(
                (*classFind)->getUnit()->getAssessment().begin(),
                (*classFind)->getUnit()->getAssessment().end(),
                [&classFind, &assmntName](Assessment* item) {
                    return item->getName() == assmntName;
                }
            );

            cout << "\nWhat score would you like to assign"
                << "\nEnter a number between 1 an 100" << endl;

            assmntStringScr = this->getInput();
            assmntScr = stoi(assmntStringScr);

            (*findAssmnt)->setScore(assmntScr);

            this->updateStudentScore(*classFind, &studFind, *findAssmnt);

        }
        else if (response == "2")
        {
            cout << "\nWhat grade would you like to assign"
                << "\nEnter F for Fail"
                << "\nEnter P for Pass"
                << "\nEnter C for Credit"
                << "\nEnter D for Disctintion"
                << "\nEnter H for High Distinction" << endl;

            grade = this->getInput();

            if (grade == "F") {
                this->updateStudentGrade(*classFind, &studFind, Grade::Fail);
            }
            else if (grade == "P") {
                this->updateStudentGrade(*classFind, &studFind, Grade::Pass);

            }
            else if (grade == "C") {
                this->updateStudentGrade(*classFind, &studFind, Grade::Credit);

            }
            else if (grade == "D") {
                this->updateStudentGrade(*classFind, &studFind, Grade::Distinction);

            }
            else if (grade == "H") {
                this->updateStudentGrade(*classFind, &studFind, Grade::HighDistinction);

            }

        }

    }
}

void QueryInterface::editUnit(Unit* unit)
{
    int code;
    string codeStr;
    string name;
    string sem;
    string desc;

    string resp;
    cout << "\nWhat field would you like to edit in the provided Unit?"
    << "\nenter 'code' for Unit Code "
    << "\nenter 'name' for Unit Name "
    << "\nenter 'sem' for Unit Semester "
    << "\nenter 'desc' for Unit Description " << endl;

    resp = this->getInput();

    if (resp == "code") {
        cout << "\nEnter the code you'd like to assign the Unit" << endl;
        codeStr = this->getInput();
        code = stoi(codeStr);

        unit->setCode(code);

    }
    else if (resp == "name") {
        cout << "\nEnter the name you'd like to assign the Unit" << endl;
        name = this->getInput();

        unit->setName(name);
    }
    else if (resp == "seme") {
        cout << "\nEnter the semester you'd like to avail the Unit" << endl;
        sem = this->getInput();

        unit->setSemester(sem);
    }
    else if (resp == "desc") {
        cout << "\nEnter the description you'd like to assign the Unit" << endl;
        desc = this->getInput();

        unit->setDescription(desc);
    }

    cout
    << "\n!!!!!!!!!  SUCCESS !!!!!!!"
    << "\nYou've successfully changed" << resp << endl;

}
void QueryInterface::updateStudentScore(ClassRoom* classrom, Student* stud, Assessment* asmnt)
{
    auto resStud = classrom->getStudent(stud->getId());
    auto resUnit = resStud.getUnit(classrom->getUnit()->getCode());
    auto resAssmnt = resUnit.getAssessment(asmnt->getName());

    (&resAssmnt)->setScore(asmnt->getScore());
    cout
    << "\n!!!!!!!!!  SUCCESS !!!!!!!"
    << "\nYou've successfully changed the score to " << (&resAssmnt)->getScore() << endl;
}

void QueryInterface::updateStudentGrade(ClassRoom* classrom, Student* stud, Grade grade)
{
    auto resStud = classrom->getStudent(stud->getId());
    auto resUnit = resStud.getUnit(classrom->getUnit()->getCode());

    (&resUnit)->setGrade(grade);
    cout
    << "\n!!!!!!!!!  SUCCESS !!!!!!!"
    << "\nYou've successfully changed the score to " << (&resUnit)->getGrade() << endl;

}
