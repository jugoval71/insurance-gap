import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as headerActions from '../actions/header';
import Header from './Header';

const mapStateToProps = (state) => {
    return ({
        header: state.insurance.header
    });
};

const mapDispatchToProps = (dispatch) => {
    return ({
        actions: {
            header: bindActionCreators(headerActions, dispatch),
        }
    });
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Header);