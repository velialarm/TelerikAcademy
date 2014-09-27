define([],function(){
    var Course;
    Course = (function(){
        function Course(title, forumula){
            this.title = title;
            this._forumula = forumula;
            this._students = [];
        }

        Course.prototype.addStudent = function(student){
            this._students.push(student);
        };

        Course.prototype.calculateResults = function(){
            var self = this;
            this._students.forEach(function(student){
                student.totalResult = self._forumula(student);
            });
        };

        Course.prototype.getTopStudentsByExam = function(count){
           return  sortStudent(this._students, count, 'exam');
        };

        Course.prototype.getTopStudentsByTotalScore = function(count){
            return  sortStudent(this._students, count, 'totalResult');
        };

        function sortStudent(students, count, sortBy){
            students.sort(function(first, second){
                return second[sortBy] - first[sortBy];
            })
            return students.slice(0, count);
        };

        return Course;
    }());

    return Course;
});