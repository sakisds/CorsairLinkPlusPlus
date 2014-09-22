/**
 * CorsairLinkPlusPlus
 * Copyright (c) 2014, Mark Dietzer & Simon Schick, All rights reserved.
 *
 * CorsairLinkPlusPlus is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or at your option any later version.
 *
 * CorsairLinkPlusPlus is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with CorsairLinkPlusPlus.
 */
"use strict";

var FanCurveController = require("classes/Controllers/FanCurveController");
var ControlCurve = require("classes/ControlCurve");

function FanCustomCurveController(rawData) {
	FanCurveController.apply(this, arguments);
}
inherit(FanCustomCurveController, FanCurveController);

FanCustomCurveController.prototype.setValue = function(newCurve) {
	this.value = newCurve;
	return this.update();
}

return FanCustomCurveController;