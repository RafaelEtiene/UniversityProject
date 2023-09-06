import {OnInit, Component} from '@angular/core';
import { StudentsService } from 'src/api/students.service';
import { StudentViewModel } from 'src/viewmodel/StudentViewModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public students: StudentViewModel[] = [];
  
  ngOnInit(): void {
    this.GetAllStudents();
  }
  constructor(private studentService: StudentsService) {
  }
  public GetAllStudents(){
    this.studentService.GetAllStudents()
      .subscribe(r =>  {
        this.students = r;
      },
      error => {
        console.error("Error fetching students", error)
      }
      );
      
  }
}
