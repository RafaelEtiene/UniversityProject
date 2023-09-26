import {OnInit, Component, TemplateRef, ViewChild} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CourseService } from 'src/api/course.service';
import { StudentsService } from 'src/api/students.service';
import { CourseViewModel } from 'src/viewmodel/CourseViewModel';
import { FilterViewModel } from 'src/viewmodel/FilterViewModel';
import { StudentViewModel } from 'src/viewmodel/StudentViewModel';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})

export class StudentComponent implements OnInit {  
  students: StudentViewModel[] = [];
  email: string = null!;
  name: string = null!;
  initialDate: Date = null!;
  finalDate: Date = null!;
  courses: CourseViewModel[] = [];
  courseSelected: number = null!;
  genderSelected: string = "";
  showTemplate: boolean = false;
  student: StudentViewModel = null!;

  @ViewChild('myTemplate') myTemplateRef!: TemplateRef<any>;

  constructor(private studentService: StudentsService, 
    modalService: NgbModal,
    private courseService: CourseService) {
  }
  ngOnInit(): void {
    this.GetAllCourses();
  }

  public GetAllStudents(){
    let filter: FilterViewModel = {
      email : this.email,
      finalDate: this.finalDate,
      initialDate: this.initialDate,
      name: this.name
    }
    this.studentService.GetAllStudents(filter)
      .subscribe(r =>  {
        this.students = r;
      }
    );    
  }
  public GetAllCourses(){
    return this.courseService.GetAllCourses()
    .subscribe(result => {
      this.courses = result;
    })
  }
  public AddStudent(){
    this.showTemplate = true;
    this.student = {
      idStudent: 0,
      name: "",
      age: 0,
      email: "",
      gender: "",
      idCourse: 0,
      phone: "",
      registrationDate: new Date
    }
  }
  public SaveStudent(){
    var insertStudent: StudentViewModel = {
      idStudent: this.student.idStudent,
      idCourse: this.courseSelected,
      name: this.student.name,
      email: this.student.email,
      age: this.student.age,
      gender: this.student.gender,
      phone: this.student.phone,
      registrationDate: this.student.registrationDate
    }
    this.studentService.InsertStudent(insertStudent).subscribe();
    this.GetAllCourses();
    this.showTemplate = false;
  }
}
