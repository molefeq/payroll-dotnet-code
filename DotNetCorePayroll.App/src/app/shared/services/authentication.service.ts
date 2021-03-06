import { Injectable } from '@angular/core';
import { UserModel } from '../generated/model/userModel';
import { AccountService, ChangePasswordModel } from '../generated';
import { Observable } from 'rxjs/Observable';
import { tap } from 'rxjs/operators/tap';

@Injectable()
export class AuthenticationService {
  constructor(private accountService: AccountService) { }

  login(username: string, password: string): Observable<UserModel> {
    return this.accountService.login({ username: username, password: password }).pipe(
      tap((userModel: UserModel) => {
        this.user = userModel;
      })
    );
  }

  logout(): void {
    localStorage.removeItem('user');
  }

  changePassword(model: ChangePasswordModel): Observable<UserModel> {
    return this.accountService.changePassword(model);
  }

  set redirectUrl(value: string) {
    sessionStorage.setItem('redirectUrl', value);
  }

  get redirectUrl(): string {
    return sessionStorage.getItem('redirectUrl');
  }

  set user(value: UserModel) {
    if (Boolean(value)) {
      localStorage.setItem('user', JSON.stringify(value));
    }
  }

  get user(): UserModel {
    const user = localStorage.getItem('user');

    if (Boolean(user)) {
      return JSON.parse(user);
    }

    return null;
  }

  get isAuthenticated(): boolean {
    return Boolean(this.user) && Boolean(this.user.id);
  }
}
