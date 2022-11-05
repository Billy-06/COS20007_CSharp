//
// Created by billy on 3/11/2022.
//

#ifndef ROVERPROJECT_OBJECT_H
#define ROVERPROJECT_OBJECT_H


class Object {

private:
    static int _count;

public:
    Object();
    Object(const Object&);
    virtual ~Object();

    static int getCount();

};


#endif //ROVERPROJECT_OBJECT_H
