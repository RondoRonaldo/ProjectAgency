import { FormGroup, AbstractControl } from '@angular/forms';

export  function passwordMatchValidator(group: AbstractControl): any {
    if(group)
    {
        if (group.get('password').value !== group.get('confirmPassword').value) {
            return { notMatching: true };
        }
    }
    return null;
}
