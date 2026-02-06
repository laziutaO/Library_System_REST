import { CanActivateChildFn } from '@angular/router';

export const adminGuardGuard: CanActivateChildFn = (childRoute, state) => {
  return true;
};
