import {OnInit, Component} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { StudentsService } from 'src/api/students.service';
import { FilterViewModel } from 'src/viewmodel/FilterViewModel';
import { StudentViewModel } from 'src/viewmodel/StudentViewModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {  
  students: StudentViewModel[] = [];
  email: string = null!;
  name: string = null!;
  initialDate: Date = null!;
  finalDate: Date = null!;

  ngOnInit(): void {
  }
  constructor(private studentService: StudentsService) {
  }
  public GetAllStudents(){
    let filter: FilterViewModel = {
      email : this.email,
      finalDate: this.finalDate,
      initialDate: this.initialDate,
      name: this.name
    }
    console.log(filter)
    this.studentService.GetAllStudents(filter)
      .subscribe(r =>  {
        this.students = r;
        console.log(this.students)
      }
      );   
      console.log(this.students);
 
  }
}
