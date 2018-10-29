import * as HeaderActionConstants from '../constants/header'

export const goTo = (route) => ({
    type: HeaderActionConstants.HEADER_ACTIVE_ROUTE_CHANGED,
    route,
});