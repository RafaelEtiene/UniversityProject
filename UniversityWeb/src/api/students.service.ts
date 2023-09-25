import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentViewModel } from '../viewmodel/StudentViewModel';
import { FilterViewModel } from 'src/viewmodel/FilterViewModel';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  public basePath: string = 'https://localhost:7180/api';

  constructor(private httpClient: HttpClient) { 
  }

  public GetAllStudents(filter: FilterViewModel) : Observable<StudentViewModel[]> {
    let params = new HttpParams();
    if(filter.initialDate != null){
      params = params.append('InitialDate', filter.initialDate.toString());
    }
    if(filter.finalDate != null){
      params = params.append('FinalDate', filter.finalDate.toString());
    }
    if(filter.name != null){
      params = params.append('Name', filter.name);
    }
    if(filter.email != null){
      params = params.append('Email', filter.email);
    }
    return this.httpClient.get<StudentViewModel[]>
    (`${this.basePath}/Student/GetAllStudents`, {params: params})
  }

  public InsertStudent(student: StudentViewModel){
    return this.httpClient.post<StudentViewModel>(`${student}/Student/InsertStudent`, student)
  }
}
