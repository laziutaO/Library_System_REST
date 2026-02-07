import { CanActivateChildFn, Router } from '@angular/router';
import { AuthService } from '../services/auth-service';
import { inject } from '@angular/core';

export const adminGuard: CanActivateChildFn = (childRoute, state) => {
  const authService = inject(AuthService);
  const router = inject(Router)
  const user = authService.currentUser();
  if(user && user.roles.includes('Admin'))
    return true;
  return router.createUrlTree(['']);
};
