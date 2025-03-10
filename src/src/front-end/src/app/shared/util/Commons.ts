import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export enum OrderListSort {
    Asc = "asc",
    Desc = "desc",
  }

export class Commons {

    static converterStringForDate(dataString: string): Date | null {


        const partes = dataString.split('/');
        const dia = parseInt(partes[0], 10);
        const mes = parseInt(partes[1], 10) - 1; // Meses começam em 0 (Janeiro = 0)
        const ano = parseInt(partes[2], 10);

        // Criar um objeto Date
        const data = new Date(ano, mes, dia);

        // Verificar se a data criada é válida
        if (data.getFullYear() !== ano || data.getMonth() !== mes || data.getDate() !== dia) {
            console.error("Data inválida.");
            return null; // Retorna null se a data for inválida
        }

        return data;
    }

    // phone-formatter.util.ts
 static formatPhone(phoneString: string): string {
    // Remove todos os caracteres que não sejam números
    const cleanString = phoneString.replace(/\D/g, '');

    if (cleanString.length == 2) {
        const ddd = cleanString.substring(0, 2);
        return `(${ddd}) `; // Apenas DDD
    } else if (cleanString.length == 4 || cleanString.length == 5 || cleanString.length == 6) {
        const ddd = cleanString.substring(0, 2);
        const part1 = cleanString.substring(2, cleanString.length);
        return `(${ddd}) ${part1}`; // Parcial com DDD
    } else if (cleanString.length >= 11) {
        const ddd = cleanString.substring(0, 2);
        const part1 = cleanString.substring(2, 7);
        const part2 = cleanString.substring(7, 11);
        return `(${ddd}) ${part1}-${part2}`; // Formato celular
    } else if (cleanString.length >= 10) {
        const ddd = cleanString.substring(0, 2);
        const part1 = cleanString.substring(2, 6);
        const part2 = cleanString.substring(6, 10);
        return `(${ddd}) ${part1}-${part2}`; // Formato residencial
    } else if (cleanString.length == 6) {
        const ddd = cleanString.substring(0, 2);
        const part1 = cleanString.substring(2, cleanString.length);
        return `(${ddd}) ${part1}`; // Parcial com DDD
    }
    return cleanString; // Retorna o texto original se o número for inválido
  }


    static emailValidator(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
          const value = control.value;

          if (!value) {
            return { invalidEmail: true };
          }

          // Expressão regular para validar e-mail
          const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
          const isValidEmail = emailPattern.test(value);

          return isValidEmail ? null : { invalidEmail: true };
        };
      }

    static fieldsMatchValidator(controlName: string,
         matchingControlName: string): ValidatorFn {
        return (formGroup: AbstractControl): ValidationErrors | null => {
            const valor1 = formGroup.get(controlName)?.value;
            const valor2 = formGroup.get(matchingControlName)?.value;

            if (valor1 !== valor2) {
              return { fieldsDoNotMatch: true };
            }

            return null;

          return null;
        };
      }

    static minLengthValidator(minLength: number = 8): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
          const value = control.value;

          if (value && value.length < minLength) {
            return { minLength: { requiredLength: minLength, actualLength: value.length } };
          }

          return null;
        };
      }

    static cpfCnpjValidator(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
          const value = control.value;


          const isValidCPF =  this.validateCPF(value);
          const isValidCNPJ = this.validateCNPJ(value);

          if (!isValidCPF &&  !isValidCNPJ) {
            return { invalidCpfCnpj: true };
          }

          return null;
        };
      }

      static validateCPF(cpf: string): boolean {
        cpf = cpf.replace(/[^\d]+/g, '');
        if (cpf.length !== 11 || /^(\d)\1+$/.test(cpf)) {
          return false;
        }

        let sum = 0;
        let remainder;

        for (let i = 1; i <= 9; i++) {
          sum += parseInt(cpf.substring(i - 1, i), 10) * (11 - i);
        }
        remainder = (sum * 10) % 11;

        if (remainder === 10 || remainder === 11) remainder = 0;
        if (remainder !== parseInt(cpf.substring(9, 10), 10)) return false;

        sum = 0;
        for (let i = 1; i <= 10; i++) {
          sum += parseInt(cpf.substring(i - 1, i), 10) * (12 - i);
        }
        remainder = (sum * 10) % 11;

        if (remainder === 10 || remainder === 11) remainder = 0;
        return remainder === parseInt(cpf.substring(10, 11), 10);
      }

      static validateCNPJ(cnpj: string): boolean {
        cnpj = cnpj.replace(/[^\d]+/g, '');
        if (cnpj.length !== 14 || /^(\d)\1+$/.test(cnpj)) {
          return false;
        }

        let length = cnpj.length - 2;
        let numbers = cnpj.substring(0, length);
        const digits = cnpj.substring(length);
        let sum = 0;
        let pos = length - 7;

        for (let i = length; i >= 1; i--) {
          sum += parseInt(numbers.charAt(length - i), 10) * pos--;
          if (pos < 2) pos = 9;
        }

        let result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        if (result !== parseInt(digits.charAt(0), 10)) return false;

        length += 1;
        numbers = cnpj.substring(0, length);
        sum = 0;
        pos = length - 7;

        for (let i = length; i >= 1; i--) {
          sum += parseInt(numbers.charAt(length - i), 10) * pos--;
          if (pos < 2) pos = 9;
        }

        result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        return result === parseInt(digits.charAt(1), 10);
      }

    static sortCollection<T>(
        collection: T[],
        column: keyof T,
        order: OrderListSort = OrderListSort.Asc
      ): T[] {
        return collection.slice().sort((a, b) => {
          const valA = a[column];
          const valB = b[column];

          // Comparação para valores `undefined`, `null` e strings vazias ""
          if (valA == null || valA === "") return order === OrderListSort.Asc ? -1 : 1;
          if (valB == null || valB === "") return order === OrderListSort.Asc ? 1 : -1;

          // Comparação para tipo `string`
          if (typeof valA === "string" && typeof valB === "string") {
            return order === OrderListSort.Asc
              ? valA.localeCompare(valB)
              : valB.localeCompare(valA);
          }

          // Comparação para tipo `boolean`
          if (typeof valA === "boolean" && typeof valB === "boolean") {
            return order === OrderListSort.Asc
              ? (valA === valB ? 0 : valA ? -1 : 1)
              : (valA === valB ? 0 : valA ? 1 : -1);
          }

          // Comparação para tipo `number`
          if (typeof valA === "number" && typeof valB === "number") {
            return order === OrderListSort.Asc ? valA - valB : valB - valA;
          }

          // Comparação para tipo `symbol`
          if (typeof valA === "symbol" && typeof valB === "symbol") {
            const symA = Symbol.keyFor(valA) ?? valA.toString();
            const symB = Symbol.keyFor(valB) ?? valB.toString();
            return order === OrderListSort.Asc ? symA.localeCompare(symB) : symB.localeCompare(symA);
          }

          // Comparação para tipo `Date`
          if (valA instanceof Date && valB instanceof Date) {
            return order === OrderListSort.Asc ? valA.getTime() - valB.getTime() : valB.getTime() - valA.getTime();
          }

          return 0; // Caso nenhum tipo específico seja tratado, retorna como igual
        });
      }

   static generateRandomString(tamanho: number): string {
        const caracteres = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        if (tamanho > caracteres.length) {
            throw new Error('O tamanho solicitado é maior do que a quantidade de caracteres únicos disponíveis.');
        }
        const resultado: string[] = [];
        const usado: Set<string> = new Set();

        while (resultado.length < tamanho) {
            const indiceAleatorio = Math.floor(Math.random() * caracteres.length);
            const charAleatorio = caracteres[indiceAleatorio];

            // Verifica se o caractere já foi usado
            if (!usado.has(charAleatorio)) {
                usado.add(charAleatorio);
                resultado.push(charAleatorio);
            }
        }

        return resultado.join('');

    }

    static toQueryString(obj: any): string {
        const params: string[] = [];

        for (const key in obj) {
            if (obj[key] !== null && obj[key] !== undefined) {
                let value = obj[key];
                if (value instanceof Date) {
                    // Convertendo a data para o formato yyyy-mm-dd
                    value = value.toISOString().split('T')[0]; // Obtém apenas a parte da data
                }
                params.push(`${encodeURIComponent(key)}=${encodeURIComponent(value)}`);
            }
        }

        return params.length ? '?' + params.join('&') : '';
    }

    static generateGUID():string
    {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c) => {
            const r = Math.random() * 16 | 0;
            const v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });

    }

    static  formatDateToDDMMYYYY(date: Date): string {
        const year = date.getFullYear();
        const month = (date.getMonth() + 1).toString().padStart(2, '0'); // getMonth() retorna 0-11, então adicionamos 1
        const day = date.getDate().toString().padStart(2, '0');

        return `${day.toString().padStart(2,'0')}/${month.toString().padStart(2,'0')}/${year}`;
    }
    static  formatDateToYYYYMMDD(date: Date): string {
        const year = date.getFullYear();
        const month = (date.getMonth() + 1).toString().padStart(2, '0'); // getMonth() retorna 0-11, então adicionamos 1
        const day = date.getDate().toString().padStart(2, '0');

        return `${year}-${month}-${day}`;
    }

}
