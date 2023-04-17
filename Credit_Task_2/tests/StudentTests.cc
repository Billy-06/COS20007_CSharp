#include "Student.h"
#include "gtest/gtest.h"


class StudentTest : public ::testing::Test
{
protected:

    StudentTest()
    {

    }
    ~StudentTest() override
    {

    }

    Unit* unit0 = new Unit(
        "Artificial Intelligence",
        "Semester 2",
        "This unit introduces the fundamentals of Artificial Intelligence"
    );
    Unit* unit1 = new Unit(
        "Machine Learning",
        "Semester 2",
        "This unit introduces the fundamentals of Machine Learning"
    );
    Unit* unit2 = new Unit(
        "Object Oriented Programming",
        "Semester 2",
        "This unit introduces the fundamentals of Object Oriented Programming"
    );

    Student* stud = new Student();
    void SetUp() override
    {
        unit0->setGrade(Grade::Distinction);
        unit1->setGrade(Grade::HighDistinction);
        unit2->setGrade(Grade::Distinction);

        stud->addUnit(unit0);
        stud->addUnit(unit1);
        stud->addUnit(unit2);

    }

    void TearDown() override
    {
        delete unit0;
        delete unit1;
        delete unit2;

        delete stud;
    }
};

TEST_F(StudentTest, AddingUnits){
    ASSERT_TRUE(stud->semesterUnits().size() == 3 );
}

int main(int argc, char **argv)
{
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}
