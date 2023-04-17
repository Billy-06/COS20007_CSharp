#include "ClassRoom.h"
#include "Lecturer.h"
#include "Unit.h"
#include <string>
#include <algorithm>
#include <vector>


class QueryInterface
{
public:

    vector<Lecturer*> _lecturers;
    vector<Student*> _students;
    vector<Unit*> _units;
    vector<ClassRoom*> _classes;

    QueryInterface();
    ~QueryInterface();

    string getInput();
    void welcomePage();

    void login(User* item);
    void logout(User* item);
    void enroll(Student* stud, Unit* unit);
    void viewUnits();

    void studentHomepage(Student* stud);
    void lecturerHomepage(Lecturer* lec);

    string studentNavigation(Student* stud);
    string lecturerNavigation(Lecturer* lec);

    void createUnit();
    void updateResults(Lecturer* lec);
    void editUnit(Unit* unit);
    void updateStudentScore(ClassRoom* classrom, Student* stud, Assessment* asmnt);
    void updateStudentGrade(ClassRoom* classrom, Student* stud, Grade grade);

};
