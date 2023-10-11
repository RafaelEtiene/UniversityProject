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
  showTemplate: boolean = false;
  student: StudentViewModel = null!;

  @ViewChild('myTemplate') myTemplateRef!: TemplateRef<any>;

  constructor(private studentService: StudentsService, 
    modalService: NgbModal,
    private courseService: CourseService) {
  }
  ngOnInit(): void {
    this.getAllCourses();
  }

  public getAllStudents(){
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

  public getAllCourses(){
    return this.courseService.GetAllCourses()
    .subscribe(result => {
      this.courses = result;
    })
  }

  public getStudentById(idStudent: number){
    this.showTemplate = true;
    return this.studentService.GetStudentById(idStudent).subscribe(r => {
      this.student = r;
    })
  }

  public cancel(){
    this.showTemplate = false;
  }

  public addStudent(){
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

  public saveStudent(){
    if(this.student.idStudent != 0){
      this.studentService.UpdateStudent(this.student).subscribe();
    } 
    else{
      this.studentService.InsertStudent(this.student).subscribe();
    }
    this.showTemplate = false;
    this.getAllCourses();
  }
}
