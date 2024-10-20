export function Event(location, category, project, portalUsers){
    function getLocation(){
        return location;
    }
    function getPlace(){
        return place;
    }
    function getProject(){
        return project;
    }
    function getPortalUsers(){
        return portalUsers;
    }
    return {getLocation, getPlace, getProject, getPortalUsers};
}

export function projectListingData( value, type, unit, event, clientnames)
{
    function getValue(){
        return value;
    }
    function getPropertyType(){
        return type;
    }
    function getUnit(){
        return unit;
    }

    function getEvent(){
        return event;
    }

    function getClientnames(){
        return clientnames;
    }

    return {getPropertyType, getValue, getUnit, getEvent, getClientnames};
}

export function Temperature(projectListingData){
    const value = projectListingData.getValue();
    const unit = projectListingData.getUnit();
    const clientnames = projectListingData.getClientnames();
    const type = projectListingData.getPropertyType();
    
    function getClientnames(){
        return clientnames;
    }
    
    function getPropertyType(){
        return type;
    }

    function getUnit(){
        return unit;
    }
    function getValue(){
        return value;
    }
    function getEvent(){
        return projectListingData.getEvent();
    }
    
    function toString(){return value + "" + unit}
    
    return {toString, getValue, getUnit, getEvent, getClientnames, getPropertyType};

}