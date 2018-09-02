
function CheckItem(sender, args)
{
     var chkControlId = '<%=chkLstCategory.ClientID%> '
    var options = document.getElementById(chkControlId).getElementsByTagName('input');
    var ischecked=false;
    args.IsValid =false;
    for(i=0;i<options.length;i++)
    {
        var opt = options[i];
        if(opt.type=="checkbox")
        {
            if(opt.checked)
            {
                ischecked= true;
                args.IsValid = true;                
            }
        } 
    }
}