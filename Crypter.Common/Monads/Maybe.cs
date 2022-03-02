﻿/*
 * Copyright (C) 2022 Crypter File Transfer
 * 
 * This file is part of the Crypter file transfer project.
 * 
 * Crypter is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The Crypter source code is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Affero General Public License for more details.
 * 
 * You should have received a copy of the GNU Affero General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * You can be released from the requirements of the aforementioned license
 * by purchasing a commercial license. Buying such a license is mandatory
 * as soon as you develop commercial activities involving the Crypter source
 * code without disclosing the source code of your own applications.
 * 
 * Contact the current copyright holder to discuss commercial license options.
 */

using System;

namespace Crypter.Common.Monads
{
   public class Maybe<TValue> where TValue : class
   {
      private readonly TValue _value;

      public Maybe(TValue value)
      {
         _value = value ?? throw new ArgumentNullException(nameof(value));
      }

      private Maybe()
      {
      }

      public void IfSome(Action<TValue> someAction)
      {
         if (someAction == null)
         {
            throw new ArgumentNullException(nameof(someAction));
         }

         if (_value != default)
         {
            someAction(_value);
         }
      }

      public void IfNone(Action noneAction)
      {
         if (noneAction == null)
         {
            throw new ArgumentNullException(nameof(noneAction));
         }

         if (_value == default)
         {
            noneAction();
         }
      }

      public TOut Match<TOut>(Func<TValue, TOut> someFunction, Func<TOut> noneFunction)
      {
         if (someFunction == null)
         {
            throw new ArgumentNullException(nameof(someFunction));
         }

         if (noneFunction == null)
         {
            throw new ArgumentNullException(nameof(noneFunction));
         }
         
         return _value == default
            ? noneFunction()
            : someFunction(_value);
      }

      public static Maybe<TValue> None() => new Maybe<TValue>();
   }
}
