
        $(function(){


            $("#extruderLeft").buildMbExtruder({
                position:"left",
                width:300,
                extruderOpacity:.8,
                hidePanelsOnClose:true,
                accordionPanels:true,
                onExtOpen:function(){},
                onExtContentLoad:function(){},
                onExtClose:function(){}
            });



            /*
             $("#extruderLeft").buildMbExtruder({
             position:"left",
             width:300,
             extruderOpacity:.8,
             hidePanelsOnClose:false,
             accordionPanels:false,
             onExtOpen:function(){},
             onExtContentLoad:function(){$("#extruderLeft").openPanel();},
             onExtClose:function(){}
             });
             */

            $("#extruderLeft1").buildMbExtruder({
                position:"left",
                width:300,
                extruderOpacity:.8,
                onExtOpen:function(){},
                onExtContentLoad:function(){},
                onExtClose:function(){}
            });

            $("#extruderLeft2").buildMbExtruder({
                position:"left",
                width:300,
                extruderOpacity:.8,
                onExtOpen:function(){},
                onExtContentLoad:function(){},
                onExtClose:function(){}
            });
        });
		
