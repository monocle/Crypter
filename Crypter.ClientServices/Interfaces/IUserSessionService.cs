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

using Crypter.ClientServices.DeviceStorage.Models;
using Crypter.ClientServices.Interfaces.Events;
using Crypter.Common.Monads;
using Crypter.Common.Primitives;
using Crypter.Contracts.Features.Authentication;
using System;
using System.Threading.Tasks;

namespace Crypter.ClientServices.Interfaces
{
   public interface IUserSessionService
   {
      Maybe<UserSession> Session { get; }

      Task<bool> IsLoggedInAsync();
      Task<Either<LoginError, Unit>> LoginAsync(Username username, Password password, bool rememberUser);
      Task<bool> TestPasswordAsync(Password password);
      Task<Unit> LogoutAsync();

      event EventHandler<UserSessionServiceInitializedEventArgs> ServiceInitializedEventHandler;
      event EventHandler<UserLoggedInEventArgs> UserLoggedInEventHandler;
      event EventHandler UserLoggedOutEventHandler;
      event EventHandler<UserPasswordTestSuccessEventArgs> UserPasswordTestSuccessEventHandler;
   }
}
